hasUsername: aString
	"Answer true if the given string contains the user's name."

	^((aString asLowercase)
		findString: (Celeste userName) asLowercase
		startingAt: 1) ~= 0