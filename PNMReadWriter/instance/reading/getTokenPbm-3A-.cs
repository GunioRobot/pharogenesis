getTokenPbm: aCollection
	"get a number, return rest of collection"
	| line tokens token |
	tokens _ aCollection.
	tokens size = 0 ifTrue:[
		[
			line _ self pbmGetLine.
			line ifNil:[^{nil . nil}].
			tokens _ line findTokens: ' '.
			tokens size = 0
		] whileTrue:[].
	].
	"Transcript cr; show: tokens asString."
	token _ tokens removeFirst.
	^{token asInteger . tokens}
