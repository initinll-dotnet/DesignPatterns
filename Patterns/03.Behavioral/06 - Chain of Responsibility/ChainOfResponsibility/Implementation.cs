using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility;

public class Document
{
    public string Title { get; set; }
    public DateTimeOffset LastModified { get; set; }
    public bool ApprovedByLitigation { get; set; }
    public bool ApprovedByManagement { get; set; }

    public Document(
        string title,
        DateTimeOffset lastModified,
        bool approvedByLitigation,
        bool approvedByManagement)
    {
        Title = title;
        LastModified = lastModified;
        ApprovedByLitigation = approvedByLitigation;
        ApprovedByManagement = approvedByManagement;
    }
}


/// <summary>
/// Handler
/// </summary> 
public interface IHandler<T> where T : class
{
    IHandler<T> SetSuccessor(IHandler<T> successor);
    void Handle(T request);
}

/// <summary>
/// ConcreteHandler
/// </summary>
public class DocumentTitleHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document document)
    {
        if (document.Title == string.Empty)
        {
            var validationResult = new ValidationResult(
                    errorMessage: "Title must be filled out",
                    memberNames: ["Title"]);

            // validation doesn't check out
            throw new ValidationException(
                validationResult: validationResult,
                validatingAttribute: null,
                value: null);
        }

        // go to the next handler
        _successor?.Handle(document);
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return successor;
    }
}

/// <summary>
/// ConcreteHandler
/// </summary>
public class DocumentLastModifiedHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document document)
    {
        if (document.LastModified < DateTime.UtcNow.AddDays(-30))
        {
            // validation doesn't check out
            var validationResult = new ValidationResult(
                    errorMessage: "Document must be modified in the last 30 days",
                    memberNames: ["LastModified"]);

            // validation doesn't check out
            throw new ValidationException(
                validationResult: validationResult,
                validatingAttribute: null,
                value: null);
        }

        // go to the next handler
        _successor?.Handle(document);
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return successor;
    }
}

/// <summary>
/// ConcreteHandler
/// </summary>
public class DocumentApprovedByLitigationHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document document)
    {
        if (!document.ApprovedByLitigation)
        {
            // validation doesn't check out
            var validationResult = new ValidationResult(
                    errorMessage: "Document must be approved by litigation",
                    memberNames: ["ApprovedByLitigation"]);

            // validation doesn't check out
            throw new ValidationException(
                validationResult: validationResult,
                validatingAttribute: null,
                value: null);
        }

        // go to the next handler
        _successor?.Handle(document);
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return successor;
    }
}

/// <summary>
/// ConcreteHandler
/// </summary>
public class DocumentApprovedByManagementHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document document)
    {
        if (!document.ApprovedByManagement)
        {
            // validation doesn't check out
            var validationResult = new ValidationResult(
                    errorMessage: "Document must be approved by management",
                    memberNames: ["ApprovedByManagement"]);

            // validation doesn't check out
            throw new ValidationException(
                validationResult: validationResult,
                validatingAttribute: null,
                value: null);
        }

        // go to the next handler
        _successor?.Handle(document);
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return successor;
    }
}
