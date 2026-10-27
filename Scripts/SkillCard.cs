public class SkillCard
{
    public int Id { get; set; }
    public string CardName { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }

    public SkillCard(int id, string cardName, int quantity, string description)
    {
        Id = id;
        CardName = cardName;
        Quantity = quantity;
        Description = description;
    }
}
