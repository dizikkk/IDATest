using Cysharp.Threading.Tasks;

namespace IDATest
{
    public interface IJsonDownloadService
    {
        public UniTask Download();
    }
}