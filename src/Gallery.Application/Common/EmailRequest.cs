namespace Gallery.Application.Common;

public record EmailRequest(
    string[] To,
    string Subject,
    string Body 
);