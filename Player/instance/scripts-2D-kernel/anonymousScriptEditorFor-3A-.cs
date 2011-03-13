anonymousScriptEditorFor: aPhraseTileMorph
	| aScriptEditor aUserScript |
	self isFlagshipForClass ifFalse:
		[self flag: #deferred.
		self inform: 'sorry, for the moment you cannot tear
off a new anonymous script for
any instance of a uniclass other
than the flagship instance.  If this
makes no sense to you,  you
surely got here in error'.
		self error: 'Please close this window'].

	aUserScript _ self class anonymousUserScriptFor: self unusedScriptName player: self.
	aScriptEditor _ aUserScript instantiatedScriptEditor.
	aPhraseTileMorph
		ifNotNil:
			[aScriptEditor scriptName: aUserScript selector phrase: aPhraseTileMorph]
		ifNil:
			[aScriptEditor startOutEmptyForScriptName: aUserScript selector].
	^ aScriptEditor