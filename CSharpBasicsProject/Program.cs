static void GetTheTime()
{
    Thread.Sleep(5000);
    Console.WriteLine("The time now is {0}", DateTime.Now);
}

//Synch Call
//GetTheTime();

//Create Asynch call by task
Task task1 = new Task(new Action(GetTheTime));

//Create task and run it immediatly
Task task2 = Task.Run(() => {
    Thread.Sleep(5000);
    Console.WriteLine("The time now is {0}", DateTime.Now);
});

//create task that return result
Task<string> task3 = Task.Run<string>(() => {

    Thread.Sleep(5000); 
    return DateTime.Now.DayOfWeek.ToString();
      
});


////Creating an Awaitable Asynchronous Method .. a method that will be called async
async Task<string> GetData()
{
    var result = await Task.Run<string>(() =>
    {
        // Simulate a long-running task.
        Thread.Sleep(5000);
        return "Operation Complete.";
    });
    return result;
}



Console.WriteLine("Waiting for task to finish execuation ....");
//task1.Start();
//task2.Wait();
//Console.WriteLine(task3.Result);
Console.WriteLine(await GetData());
Console.WriteLine("Press Enter to continue ..");
Console.ReadLine();

