classComment: aString 
	"Store the comment, aString, associated with the object that refers to the 
	receiver."

	(aString isKindOf: RemoteString) 
		ifTrue: [globalComment _ aString]
		ifFalse: [aString size = 0
			ifTrue: [globalComment _ nil]
			ifFalse: [
				self error: 'use aClass classComment:'.
				globalComment _ RemoteString newString: aString onFileNumber: 2]]
				"Later add priorSource and date and initials?"