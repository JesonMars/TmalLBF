using Entity;

namespace BusinessInterface.DestMake
{
    public interface IMakeBaseBusiness:IBaseBusiness
    {
        bool Make(MakeDestEntity entity);
    }
}