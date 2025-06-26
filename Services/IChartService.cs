using Assignment.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Services;

public interface IChartService
{
    public byte[] GeneratePieChartStream(List<Employee> employees);
}