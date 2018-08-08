# CSharp-Distributions-Library
Library of various distributions. Minor extensibility.
This library was created to keep a large number of distribution functions in one place for easy access. 
Each distribution is represented as a class that inherits from a base distribution class. 

The base distribution class contains a two key abstract functions: sample and AreParametersValid. 
The sample method aquires a random sample from the distribution and returns it as a double. 
The AreParametersValid method checks if the parameters for the distribution were set up correctly. If they were it returns true. 

Each distribution accepts its parameters into its constructor so that it'll be obvious what values it needs.
Each distribution also has a static Sample method that lets you pass in the variables without creating an instance of the class to get a sample. 

The distribution classes all need a random number generator of some sort to create their random values. This generator can be set using the distribution's Random variable of class Generator. Generator is an abstract class that lets the user define how random numbers will be generated. A default generator is used if the user doesn't set the distributions generator value. The default generator uses Microsoft's Random class.

Right now the project does not have an excess amount of extensibility because it was needed for my purposes.
