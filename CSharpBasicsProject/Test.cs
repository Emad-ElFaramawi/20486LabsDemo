//// The Microsoft® .NET Framework now includes the Task Parallel Library.
//// This is a set of classes that makes it easy to distribute your code execution across multiple threads
//// *************************************************************************************************
//// The Task class lies at the heart of the Task Parallel //Library in the .NET Framework.
//// you use the Task class to represent a task, or in other words, a unit of work.
//// The Task class enables you to perform multiple tasks concurrently, each on a different thread.
//// Behind the scenes, the Task Parallel Library manages the thread pool and assigns tasks to threads.
//// ***************************************************************************************************

//Task task1 = new Task(new Action(GetTheTime));

//static void GetTheTime()
//{
//    Console.WriteLine("The time now is {0}", DateTime.Now);
//}

////A more common approach is to use an anonymous method. 
////An anonymous method is a method without a name, and you provide the code for
////an anonymous method inline, at the point you need to use it. You can use the delegate keyword to
////convert an anonymous method into a delegate.

//Task task2 = new Task(delegate
//{
//    Console.WriteLine("The time now is {0}", DateTime.Now);
//});


////A lambda expression is a shorthand syntax that provides a simple and concise way to define anonymous
////delegates
//// (input parameters) => expression
//Task task3 = new Task(() => { Console.WriteLine("The time now is {0}", DateTime.Now); });


//// Controlling Task Execution
//// The task runs on a separate thread, so your code does not need to wait for the
//// task to complete
//task1.Start();

////you can use the static TaskFactory class to create and queue a task with a single line of
////code
//var task4 = Task.Factory.StartNew(() => Console.WriteLine("The time now is {0}", DateTime.Now) );

////if you simply want to queue some code with the default scheduling options
//var task5 = Task.Run(() => Console.WriteLine("The time now is {0}", DateTime.Now));

////Waiting for Tasks
////Waiting for a Single Task to Complete
////******************************************
//var task6= Task.Run(() => Thread.Sleep(5000));
//// Do some other work.
//// Wait for task 1 to complete.
//task6.Wait();
//// Continue with execution.


////Waiting for Multiple Tasks to Complete
////*******************************************
//Task[] tasks = new Task[3]
//{
//Task.Run( () => Thread.Sleep(5000)),
//Task.Run( () => Thread.Sleep(5000)),
//Task.Run( () => Thread.Sleep(5000))
//};
//// Wait for any of the tasks to complete.
//Task.WaitAny(tasks);
//// Alternatively, wait for all of the tasks to complete.
//Task.WaitAll(tasks);
//// Continue with execution.


//// Returning a Value from a Task
//// Create and queue a task that returns the day of the week as a string.
//// If you access the Result property before the task has finished running, your code will wait until a result is
//// available before proceeding.
//Task<string> task7 = Task.Run<string>(() => DateTime.Now.DayOfWeek.ToString());
//// Retrieve and display the task result.
//Console.WriteLine(task7.Result);

////Cancelling Long-Running Tasks
////Canceling a Task by Throwing an Exception
//// Create a cancellation token source and obtain a cancellation token.
//CancellationTokenSource cts = new CancellationTokenSource();
//CancellationToken ct = cts.Token;
//// Create and start a task.
//Task.Run(() => doWork(ct));
//// Method run by the task.
//static void doWork(CancellationToken token)
//{
//    //…
//    // Throw an OperationCanceledException if cancellation was requested.
//    token.ThrowIfCancellationRequested();
//    // If the task has not been cancelled, continue running as normal.
//    //…
//}


////Using async and await
////You use the
////async modifier to indicate that a method is
////asynchronous. Within the async method, you use
////the await operator to indicate points at which the
////execution of the method can be suspended while
////you wait for a long-running operation to return.
////While the method is suspended at an await point,
////the thread that invoked the method can do other
////work.

////the async and await keywords enable you to run logic asynchronously on a single thread.
////This is particularly useful when you want to run logic on the UI thread, 
////because it enables you to run logic
////asynchronously on the same thread without blocking the UI

//async void btnLongOperation_Click(object sender)
//{
//    //lblResult.Content = "Commencing long-running operation…";
//    Task<string> task1 = Task.Run<string>(() => {
//        // This represents a long-running operation.
//        Thread.Sleep(10000);
//        return "Operation Complete";
//    });
//    // This statement is invoked when the result of task1 is available.
//    // In the meantime, the method completes and the thread is free to do other work.
//    //lblResult.Content = await task1;
//};

////This example includes two key changes from the previous example:
////􀁸􀀃 The method declaration now includes the async keyword.
////􀁸􀀃 The blocking statement has been replaced by an await operator.
////Notice that when you use the await operator, you do not await the result of the task—you await the task
////itself. When the .NET runtime executes an async method, it effectively bypasses the await statement until
////the result of the task is available. The method returns and the thread is free to do other work. When the
////result of the task becomes available, the runtime returns to the method and executes the await
////statement.


////Creating an Awaitable Asynchronous Method .. a method that will be called async
//async Task<string> GetData()
//{
//    var result = await Task.Run<string>(() =>
//    {
//        // Simulate a long-running task.
//        Thread.Sleep(10000);
//        return "Operation Complete.";
//    });
//    return result;
//}

////The GetData method returns a task, so you can use the method with the await operator. For example,
////you might call the method in the event handler for the click event of a button and use the result to set
////the value of a label named lblResult.


////Calling an Awaitable Asynchronous Method
//async void btnGetData_Click(object sender) {
//    //lblResult.Content = await GetData();
//}

