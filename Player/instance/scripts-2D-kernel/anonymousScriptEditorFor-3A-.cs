anonymousScriptEditorFor: aPhraseTileMorph
	| aScriptEditor aUserScript |
	self isFlagshipForClass ifFalse:
		[^ aPhraseTileMorph].

	aUserScript _ self class anonymousUserScriptFor: self unusedScriptName player: self.
	aScriptEditor _ aUserScript instantiatedScriptEditor.
	aPhraseTileMorph
		ifNotNil:
			[aScriptEditor scriptName: aUserScript selector phrase: aPhraseTileMorph]
		ifNil:
			[aScriptEditor startOutEmptyForScriptName: aUserScript selector].
	^ aScriptEditor