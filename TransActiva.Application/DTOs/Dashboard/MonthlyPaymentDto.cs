namespace TransActiva.Application.DTOs.Dashboard;

public class MonthlyPaymentDto
{
    public string Mes { get; set; } = string.Empty; // Ej: "2025-06"
    public decimal TotalPagado { get; set; }
}