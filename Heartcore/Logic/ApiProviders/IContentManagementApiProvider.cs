using System;
namespace Heartcore.Logic.ApiProviders
{
	public interface IContentManagementApiProvider
	{
		public Task<string?> CreateContentAsync<T>(T request);
	}
}

