isBreakableAt: index in: text

	| char |
	char _ text at: index.
	char = Character space ifTrue: [^ true].
	char = Character cr ifTrue: [^ true].
	^ false.
