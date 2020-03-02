# LiteDB.StateStore

[![Build Status](https://dev.azure.com/FuturistiCoder/LiteDB.Realtime/_apis/build/status/FuturistiCoder.LiteDB.Realtime?branchName=master)](https://dev.azure.com/FuturistiCoder/LiteDB.Realtime/_build/latest?definitionId=9&branchName=master)

## Get started

You can get, set or even subscribe a KeyValue state without writing actions nor reducers.

```C#
// a helper which can collect all your subscriptions
var subscriptions = new SubscriptionManager();
using (var db = new RealtimeLiteDatabase(new MemoryStream()))
{
    // subscribe to username
    subscriptions += db.StateStore<string>("username").Subscribe(username =>
        Dispatcher.BeginInvokeOnMainThread(() =>
        {
            userLabel.Text = username;
        }));

    db.StateStore<string>("username").Set("FuturistiCoder");
    // userLabel.Text will be 'FuturistiCoder';
}
```

`StateStore<T>` : the `T` can be `reference type` or `value type`. But if you want to save and listen collections, use `db.Realtime.Collection<T>` instead ([LiteDB.Realtime](https://github.com/FuturistiCoder/LiteDB.Realtime)).

```C#
subscriptions += db.Realtime.Collection<TodoItem>("TodoItems").Subscribe(items =>
    Dispatcher.BeginInvokeOnMainThread(() =>
    {
        listView.ItemsSource = items;
    })
    // listView will be updated after TodoItems changed
); 
```

Call `subscriptions.Dispose()`will dispose all your added subscriptions.
