ascentOf: aCharacter

	| encoding f |
	((aCharacter isMemberOf: Character) or: [aCharacter leadingChar = 0]) ifTrue: [
		^ (fontArray at: 1) ascent.
	].
	encoding _ aCharacter leadingChar + 1.
	[f _ fontArray at: encoding] on: Exception do: [:ex | f _ fontArray at: 1].
	f ifNil: [f _ fontArray at: 1].
	^ f ascent.
