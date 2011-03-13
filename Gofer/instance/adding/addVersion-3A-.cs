addVersion: aString
	"Add the version aString to the receiver."

	^ self add: (GoferVersionReference name: aString repository: self repository)