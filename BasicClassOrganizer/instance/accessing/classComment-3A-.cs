classComment: aString 
	"Store the comment, aString, associated with the object that refers to the 
	receiver."

	(aString isKindOf: RemoteString) 
		ifTrue: [classComment _ aString]
		ifFalse: [(aString == nil or: [aString size = 0])
			ifTrue: [classComment _ nil]
			ifFalse: [
				self error: 'use aClass classComment:'.
				classComment _ RemoteString newString: aString onFileNumber: 2]]
				"Later add priorSource and date and initials?"