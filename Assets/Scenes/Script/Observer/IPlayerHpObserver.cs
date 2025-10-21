

public interface IPlayerHpObserver //옵저버로 묶어주기 위한 인터페이스 
{
    public void OnPlayerHpChanged(float curHp, float maxHp);
}
