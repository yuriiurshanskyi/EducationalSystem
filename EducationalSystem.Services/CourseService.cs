using EducationalSystem.Infrastructure;
using EducationalSystem.Infrastructure.Entities;
using EducationalSystem.Services.DomainModels;
using ExpressionBuilder.Generics;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EducationalSystem.Services
{
    public class CourseService
    {
        private readonly EducationContext _context;

        public CourseService(EducationContext context)
        {
            _context = context;
        }

        public async Task AddCourseAsync(CourseEntity course, int userId)
        {
            course.CreatorId = userId;

            await _context.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CourseEntity>> ListCoursesAsync(FilterModel model)
        {

            var query = PredicateBuilder.New<CourseEntity>();

            if(model.CategoryId is not null)
            {
                query = query.And(x => x.CategoryId == model.CategoryId);
            }

            if (model.Ects is not null)
            {
                query = query.And(x => x.Ects <= model.Ects);
            }

            if (model.Type is not null)
            {
                query = query.And(x => x.CourseType == model.Type);
            }

            return await _context.Courses.Where(query)
                                  .Skip(model.Skip)
                                  .Take(model.Take)
                                  .ToListAsync();
        }

        public async Task<CourseEntity> GetCourseAsync(int courseId)
        {
            return await _context.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
        }

        public async Task EditCourseAsync(CourseEntity model)
        {
            var entity = await _context.Courses.FirstOrDefaultAsync(x => x.Id == model.Id);

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.EndAt = model.EndAt;
            entity.BeginsAt = model.BeginsAt;
            entity.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == courseId);

            _context.Courses.Remove(course);

            await _context.SaveChangesAsync();
        }

        public async Task<List<CourseEntity>> ListRecommendedCoursesAsync(int userId, int skip, int take)
        {
            var categoryIds = await _context.Registrations.Where(x => x.RegistreeId == userId)
                                                      .Select(x => x.Course.CategoryId)
                                                      .ToListAsync();

            var categoryPoints = categoryIds.GroupBy(x => x)
                                            .Select(g => new
                                            {
                                                CategoryId = g.Key,
                                                Count = g.Count()
                                            })
                                            .OrderByDescending(x => x.Count)
                                            .Select(x => x.CategoryId)
                                            .ToList();

            var courses = (await _context.Courses.ToListAsync())
                                                .OrderByDescending(x => categoryPoints.IndexOf(x.CategoryId))
                                                .Skip(skip)
                                                .Take(take)
                                                .ToList();

            return courses;

        }
    }
}
