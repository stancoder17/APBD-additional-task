﻿namespace WebAPI_Conferences.Models.DTOs;

public class AddEventDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Date { get; set; }
    public int MaxPeople { get; set; }
}