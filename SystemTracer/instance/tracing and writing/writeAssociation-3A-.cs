writeAssociation: obj
"when handling an Association, we need to check to see if it is one representing a class in the globals dictionary.
If it is, check to see if the class is to be substituted.
If it is, trace & write the substitute instead of the original value"
	|  actualValue |
	actualValue _ self replacementFor: obj value.
	(actualValue notNil and:[Smalltalk includes: obj value])
		ifFalse:[ actualValue _ obj value].
	self new: obj
		class: obj class
		length: (self sizeInWordsOf: obj)
		trace: [self trace: obj key. self trace: actualValue]
		write: [self writePointerField: obj key. self writePointerField: actualValue]