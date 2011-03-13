initials: aString
	"If these are changed we need to update the dictionary in the map."

	initials ~= aString ifTrue: [
		initials := aString.
		map clearUsernames]