copyAddedStateFrom: anotherObject
	"Copy the values of instance variables added by the receiver's class from anotherObject to the receiver"

	self class superclass instSize + 1 to: self class instSize do:
		[:index | self instVarAt: index put: (anotherObject instVarAt: index)]