using NetChallenge.Application.Dto.Input;

namespace NetChallenge.Application.Abstractions
{
    public interface IValidation<T>
    {
        void Validate(T request);
    }

    public interface IOfficeValidations : IValidation<AddOfficeRequest> { }

    public interface IBookingValidations: IValidation<BookOfficeRequest> { }


    public interface ILocationValidations: IValidation<AddLocationRequest> { }
}
