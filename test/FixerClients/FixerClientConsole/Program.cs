﻿using Fixerr;
using Fixerr.Configurations;
using Fixerr.Installer;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

IFixerClient client = FixerFactory.CreateFixerClient(new HttpClient(), "");

var rates = await client.GetLatestRateAsync("", "");