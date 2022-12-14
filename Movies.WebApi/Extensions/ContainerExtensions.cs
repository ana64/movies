using Microsoft.Extensions.DependencyInjection;
using Movies.Application.interfeces;
using Movies.Implementation.repositories;
using Movies.Implementation.validators;


namespace Movies.WebApi.Extensions
{
    public static class ContainerExtensions
    {

        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #region Repositories
            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IStaffRepository, StaffRepository>();
            services.AddTransient<IActorRepository, ActorRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IJobRepository, JobRepository>();
            #endregion

            #region Validators
            services.AddTransient<GenreValidator>();
            services.AddTransient<ActorValidator>();
            services.AddTransient<StaffValidator>();
            services.AddTransient<MovieValidator>();
            services.AddTransient<ReviewValidator>();
            services.AddTransient<JobValidator>();
            #endregion
        }
    }
}
