using Microsoft.Extensions.DependencyInjection;
using Movie.Core.Interfeces;
using Movie.Core.Services;
using Movie.Infrastructure.Data.Repositories;

namespace Movie.WebApi.Extensions
{
    public static class ContainerExtensions
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));

            #region Services

            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IStaffService, StaffService>();
            services.AddTransient<IActorService, ActorService>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IJobService, JobService>();
            #endregion

          
        }
    }
}
