This is an extensibility package for C#.

To use:

    Git pull
    
    Build the project.
    
    Add the amExtensibility.dll.
    
    Add a line to your importers:
        using amExtensibility;

Once included in your project, using the extensions is as simple as:

    List<string> test = new List<string>();
    
    test.Add("cheese");
    test.Add("wine");
    test.Add("waffles");
    test.Add("coffee");
    test.Add("cheese");
    
    test.RemoveDuplicates(); //this is an extension method in amExtensibility.
    test.Shuffle(); //this is an extension method in amExtensibility.