aComment
"SmartRefStream implements the 'Seeds' object storage system.  Please see the class comment.

Headlines:
	To bring in an instance of a class whose instance variables have changed, you need only define one conversion method.  The method is named
	convertxxxxx: aDictionary yyyyyy: aSmartRefStream.
Where xxxxxx is the first letters of all the instance variables in the old instance, and yyyyy are the first letters of all instance variables in the current version of the class.  A Form has inst vars 'bits width height depth offset', so version 2 of it has version tag #bwhdo2.  If the old instance had variables 'bitMap extent depth offsetPoint textDescription', its code would be #bedot0.
	Form new convertbedot0: aDictionary bwhdo3: aSmartRefStream.
All you have to do is to write the method.  aDictionary has entries (old inst var name -> value), so you can fetch the old vars by name.  See SmartRefStream.catalogValues:size:.  aSmartRefStream is available so you can get at 'structures' which tells the inst vars of other old classes in this file.

In the Squeak Goodies Folder, we provide an example.
	Suppose there once was a file named ArrayTwoDee.  If it like Array2D in this system, but is implemented differently.  ArrayTwoDee was defined like this: (Array variableSubclass: #ArrayTwoDee instanceVariableNames: 'height '...) so it is a variable class with the array values directly in the instance.  
	Array2D uses an instance var for 'contents' instead.   It has width varying most quickly, whereas the old ArrayTwoDee had height varying first.  The order of the elements must be changed.
	File in the file ConvArrayTwoDee2.st.
It defines SmartRefStream.arrayTwoDeeh2 to return Array2D, so we know what class to convert to.
It defines Array2D.converth2:wc0: to do the actual conversion.  Look at the method.  The method 'test' has the code for actually doing the conversion:
	| new2D ss |
	ss _ SmartRefStream fileNamed: 'ArrayTwoDee.test.obj'.
	new2D _ ss next.
	ss close.
	new2D class == Array2D ifFalse: [self error: 'Class conversion failed'].
	(new2D atCol: 1) = #(1 2 3 4) ifFalse: [self error: 'not flipped properly'].
	^ new2D

	The file ArrayTwoDee.test.obj has the object data in it, and is the actual file we converted.  Note that we never had to file in the old class ArrayTwoDee.  It is never needs to be defined in our system.  
	If ArrayTwoDee held an instance variable of another old class, say WeirdNumber, what form would it be in when converth2:wc0: gets run?  All objects get assigned instances in the current system before they are put into the value dictionary.  Generally, leaves of the object tree get converted first, so the values in an instance variable should be fully functioning objects in the current system.
"