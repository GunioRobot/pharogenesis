launchCustomPartsBin
	| aBin |
	(aBin _ ScriptingSystem customPartsBin) ifNotNil:
		[associatedMorph primaryHand attachMorph: aBin]