includesKey: key 
	"Answer whether the receiver has a key equal to the argument, key."
	| index |
	index _ self findElementOrNil: key.
	(array at: index) == nil	
		ifTrue: [^ false]
		ifFalse: [^ true]