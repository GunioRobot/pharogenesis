promptForSeed
	| s i |
	
	[s _ FillInTheBlank request: 'Pick a game number between 1 and 32000'.
	"Let the user cancel."
	s isEmpty ifTrue:[^nil].
	[i _ s asNumber asInteger]
		on: Error do: [i _ 0].
	i between: 1 and: 32000] whileFalse.
	^ i