using System;

public class ReservationManagerIO : DataStream
{
    private string _pathSaveFile;

    public ReservationManagerIO(string pathSaveFile)
    {
        _pathSaveFile = pathSaveFile;
    }

    public void CreateReservationPlayerData(PlayerData playerData)
    {
        if (playerData != null)
            base.Serialize(_pathSaveFile, playerData);
        else
            throw new Exception("Сохранения пусты");
    }
    public PlayerData LoadReservationPlayerData()
    {
        return base.Deserialize<PlayerData>(_pathSaveFile);
    }

    public void CreateReservationApplicationData(ApplicationData applicationData)
    {
        if (applicationData != null)
            base.Serialize(_pathSaveFile, applicationData);
        else
            throw new Exception("Сохранения пусты");
    }
    public ApplicationData LoadReservationApplicationData()
    {
        return base.Deserialize<ApplicationData>(_pathSaveFile);
    }

    public void Delete()
    {
        base.Delete(_pathSaveFile);
    }
}
