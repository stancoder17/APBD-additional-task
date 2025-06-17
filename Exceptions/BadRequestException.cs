namespace WebAPI_Conferences.Exceptions;

public class BadRequestException(string message) : Exception(message);