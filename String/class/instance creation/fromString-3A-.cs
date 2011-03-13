fromString: aString 
	"Answer an instance of me that is a copy of the argument, aString."
	
	| newString |
	newString _ self new: aString size.
	aString size do: [:i | newString at: i put: (aString at: i)].
	^newString