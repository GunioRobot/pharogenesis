permanentScriptEditorFor: aPhraseTileMorph
	| aScriptEditor aUserScript |
	self isFlagshipForClass ifFalse:
		[^ aPhraseTileMorph].

	aUserScript _ self class permanentUserScriptFor: self unusedScriptName player: self.
	aScriptEditor _ aUserScript instantiatedScriptEditor.
	aPhraseTileMorph ifNotNil:
		[aScriptEditor phrase: aPhraseTileMorph].
	aScriptEditor install.
	self updateAllViewersAndForceToShow: 'scripts'.
	^ aScriptEditor