using System.Net;

namespace Kpa.Assessment.Shared;

// allows for easy status code mappings
public enum ResultStatus
{
    Unspecified,
    ClientError,
    Succeeded = HttpStatusCode.OK,
    InvalidRequest = HttpStatusCode.BadRequest,
    MissingResource = HttpStatusCode.NotFound,
    ExpiredResource = HttpStatusCode.Gone,
    ProcessingError = HttpStatusCode.InternalServerError,
    DependencyFailure = HttpStatusCode.ServiceUnavailable,
    Conflict = HttpStatusCode.Conflict,
}