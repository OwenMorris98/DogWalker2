using DogWalker2.Application.Commands.Dogs.CreateCommands;
using DogWalker2.Application.DTOs.Dogs;
using DogWalker2.Application.Mapperly;
using DogWalker2.Domain;

namespace DogWalker2.Application.Services.Dogs
{
    public class DogService : IDogService
    {

        private readonly IDogRepository _dogRepository;

        private readonly DogMapper _mapper;
        public DogService(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
            _mapper = new DogMapper();
        }

        //public async Task<DogDTO> AddDogAsync(CreateDogCommand command)
        //{
        //    var dogToAdd = _mapper.DogDTOtoDog(command.dog);
        //    dogToAdd.Id = Guid.NewGuid().ToString();
        //    var response = await _dogRepository.AddDogAsync(dogToAdd);

        //    if (response)
        //    {
        //        return command.dog;
        //    }
        //    return new DogDTO();
        //}

        public bool AddDog(Dog dog)
        {
            return _dogRepository.AddDog(dog);
        }

        public async Task<Dog> GetDogById(string id)
        {
            return await _dogRepository.GetDogById(id);
        }

        public async Task<IEnumerable<Dog>> GetDogs()
        {
            return await _dogRepository.GetDogs();
        }

        public async Task<GetDogsByCustomerIdResponse> GetDogsByCustomerId(string customerId)
        {
            var dogs = await _dogRepository.GetDogsByCustomerId(customerId);
            GetDogsByCustomerIdResponse response = new GetDogsByCustomerIdResponse();
            foreach (var dog in dogs)
            {
                var dogDTO = _mapper.DogToDogDTO(dog);
                response.Dogs.Add(dogDTO);
            }
            return response;
           
        }

        public bool RemoveDog(Dog dog)
        {
            return _dogRepository.RemoveDog(dog);
        }

        public bool UpdateDog(Dog dog)
        {
            return _dogRepository.UpdateDog(dog);
        }

    }
}
