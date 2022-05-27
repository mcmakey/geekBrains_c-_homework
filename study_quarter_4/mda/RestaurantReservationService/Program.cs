﻿using RestaurantReservationService.Domain;
using System.Diagnostics;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var rest = new Restaurant();

TimerCallback tm = new TimerCallback(CancelBooking);
Timer timer = new Timer(tm, rest, 0, 20000);

static void CancelBooking(object obj)
{
    Restaurant r = (Restaurant)obj;
    r.CancelBooking();
}

while (true)
{
    Console.WriteLine("Привет! Желаете забронировать столик?\n1 - мы уведомим вас по смс (асинхронно)" +
        "\n2 - подождите на линии, мы Вас оповестим (синхронно)");

    if (!int.TryParse(Console.ReadLine(), out var choice ) && choice is not (1 or 2))
    {
        Console.WriteLine("Введите пожалуйста 1 или 2");
        continue;
    }

    var stopWatch = new Stopwatch();

    stopWatch.Start(); // замер затраченого времени на бронирование

    if( choice == 1)
    {
        rest.BookFreeTableAsync(1);
    }
    else
    {
        rest.BookFreeTable(1);
    }

    Console.WriteLine("Спасибо за Ваше обращение!");

    stopWatch.Stop();

    var ts = stopWatch.Elapsed;

    Console.WriteLine($"{ts.Seconds}:{ts.Milliseconds}");
}

// Всвязи с известными событиями пришлось немного отвлечься от обучения,
// поэтому д/з к уроку №2 фактически не смог не смог выполнить к установленной дате (20:00 08.03.2022).
// Все изменения по выполнению дз №2 будут влиты в этот пулл-реквест позже, но до начала следующего урока (22.03.2022).
// Спасибо.


