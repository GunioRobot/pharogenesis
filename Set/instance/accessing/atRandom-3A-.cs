atRandom: aGenerator
	"Answer a random element of the receiver.  Uses aGenerator which
	should be kept by the user in a variable and used every time. Use
	this instead of #atRandom for better uniformity of random numbers 
	because only you use the generator.  Causes an error if self has no 
	elements."
	| ind |
	self emptyCheck.
	ind _ aGenerator nextInt: array size.
	ind to: array size do:[:i|
		(array at: i) == nil ifFalse:[^array at: i]].
	1 to: ind do:[:i|
		(array at: i) == nil ifFalse:[^array at: i]].
	self errorEmptyCollection.