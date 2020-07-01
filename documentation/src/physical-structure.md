# Physical structure

## Each class should go into its own file with the same name

Only one class should be in a file. This also applies to enumeration types (enum).
Inner classes are allowed but discouraged.

## Each namespace should go into its own folder with the same name


All classes that are held together by a common purpose should go into its own namespace; the namespace should be reflected in the folder structure. If you have a namespace Example, it should be in a folder example.
Set a correct default namespace in the project, this way the tooling will help you to move classes into the correct location.


## Each project should have a test project

We write tests in a separate project, therefore each project needs a test-project.
