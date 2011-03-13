newListAndPattern: aString
	self okToChange ifFalse: [^ self].
	pattern _ aString.
	self newList