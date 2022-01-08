using LibraryService.Core.Domain;
using LibraryService.Core.Repositories;
using LibraryService.Infrastructure.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvalidCredentialException = System.Security.Authentication.InvalidCredentialException;

namespace LibraryService.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IEncrypter encrypter, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<List<AccountDto>> GetAllAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();

            return accounts is null ? new List<AccountDto>() : _mapper.Map<List<AccountDto>>(accounts);
        }

        public async Task<AccountDto> GetAsync(string email)
        {
            var account = await _accountRepository.GetAsync(email);

            if (account is null)
            {
                return null;
            }

            return _mapper.Map<AccountDto>(account);
        }

        public async Task LoginAsync(string email, string password)
        {
            var account = await _accountRepository.GetAsync(email);

            if (account is null)
            {
                throw new InvalidCredentialException();
            }

            var salt = account.Salt;
            var hash = _encrypter.CreateHash(password, salt);

            if (account.Password != hash)
            {
                throw new InvalidCredentialException();
            }
        }

        public async Task RegisterAsync(string email, string lastname, string firstname, string password)
        {
            var account = await _accountRepository.GetAsync(email);

            if (account != null)
            {
                throw new ArgumentException("This email is already used.");
            }

            var salt = _encrypter.CreateSalt(password);
            var hash = _encrypter.CreateHash(password, salt);

            account = new Account(lastname, firstname, email, hash, salt);
            await _accountRepository.AddAsync(account);
        }

        public async Task SetToken(string email, string token)
        {
            var accountDto = await GetAsync(email);

            if (string.IsNullOrEmpty(email)) {
                throw new NullReferenceException();
            }

            var account = _mapper.Map<Account>(accountDto);
            account.Token = "qwerty";
            await _accountRepository.UpdateAsync(account);
        }
    }
}