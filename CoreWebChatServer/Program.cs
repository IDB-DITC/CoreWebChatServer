using CoreWebChatServer.Hubs;

namespace CoreWebChatServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddSignalR(opt =>
            {
                opt.EnableDetailedErrors = true;
                opt.MaximumReceiveMessageSize = 1*1024*1024;
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("OpenWorld", builder =>
                    builder
                    //.AllowAnyOrigin()
                    .WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        );
            });



            var app = builder.Build();
            app.UseCors("OpenWorld");
            //app.UseCors(op =>
            //{
            //    op.AllowAnyOrigin();
            //    op.AllowAnyHeader();
            //    op.AllowAnyMethod();
            //    op.AllowCredentials();
            //});



            app.UseHttpsRedirection();



           

           
            app.MapHub<ChatHub>("/chat");
            app.Run();
        }
    }
}
