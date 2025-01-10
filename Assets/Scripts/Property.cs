using System.Collections.Generic;

public class Property
{
    public int Level { get; private set; }
    public int AvailablePoints { get; private set; }
    public int Strength { get; private set; }
    public int Speed { get; private set; }
    public int Health { get; private set; }
    public int Cooldown { get; private set; }

    // Dictionary để lưu trạng thái theo từng level
    private Dictionary<int, CharacterState> levelStates = new Dictionary<int, CharacterState>();

    public Property()
    {
        Level = 1;
        AvailablePoints = 10;
        Strength = 1;
        Speed = 1;
        Health = 1;
        Cooldown = 1;

        // Lưu trạng thái ban đầu
        SaveState();
    }

    // Tăng level
    public void LevelUp()
    {
        Level++;
        AvailablePoints += 5;

        // Nếu level chưa từng được lưu, lưu trạng thái mới
        if (!levelStates.ContainsKey(Level))
        {
            SaveState();
        }
        else
        {
            // Nếu đã tồn tại trạng thái, khôi phục trạng thái đã lưu
            RestoreState(levelStates[Level]);
        }
    }

    // Giảm level
    public void LevelDown()
    {
        if (Level > 1) // Không cho phép giảm xuống dưới Level 1
        {
            Level--;
            if (levelStates.ContainsKey(Level))
            {
                // Khôi phục trạng thái của level trước
                RestoreState(levelStates[Level]);
            }
        }
    }
    public bool UpdateStat(string statName, int value)
    {
        // Kiểm tra nếu là tăng điểm
        if (value > 0 && AvailablePoints >= value)
        {
            switch (statName.ToLower())
            {
                case "strength":
                    Strength += value;
                    break;
                case "speed":
                    Speed += value;
                    break;
                case "health":
                    Health += value;
                    break;
                case "cooldown":
                    Cooldown += value;
                    break;
                default:
                    return false;
            }
            AvailablePoints -= value; // Trừ điểm khả dụng
            SaveState(); // Lưu trạng thái mới
            return true;
        }
        // Kiểm tra nếu là giảm điểm
        else if (value < 0)
        {
            switch (statName.ToLower())
            {
                case "strength":
                    if (Strength + value >= 0) Strength += value; else return false;
                    break;
                case "speed":
                    if (Speed + value >= 0) Speed += value; else return false;
                    break;
                case "health":
                    if (Health + value >= 0) Health += value; else return false;
                    break;
                case "cooldown":
                    if (Cooldown + value >= 0) Cooldown += value; else return false;
                    break;
                default:
                    return false;
            }
            AvailablePoints -= value; // Hoàn lại điểm nếu giảm chỉ số
            SaveState(); // Lưu trạng thái mới
            return true;
        }
        return false; // Nếu không hợp lệ
    }

    // Lưu trạng thái hiện tại vào Dictionary
    private void SaveState()
    {
        levelStates[Level] = new CharacterState
        {
            Level = this.Level,
            AvailablePoints = this.AvailablePoints,
            Strength = this.Strength,
            Speed = this.Speed,
            Health = this.Health,
            Cooldown = this.Cooldown
        };
    }

    // Khôi phục trạng thái từ Dictionary
    private void RestoreState(CharacterState state)
    {
        Level = state.Level;
        AvailablePoints = state.AvailablePoints;
        Strength = state.Strength;
        Speed = state.Speed;
        Health = state.Health;
        Cooldown = state.Cooldown;
    }
}

// Lớp để lưu trạng thái nhân vật
public class CharacterState
{
    public int Level;
    public int AvailablePoints;
    public int Strength;
    public int Speed;
    public int Health;
    public int Cooldown;
}
