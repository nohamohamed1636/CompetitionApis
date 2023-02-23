using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Queries;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDetails>
    {
        public Task<StudentDetails> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
