scriptorsForSelector: aSelector inWorld: aWorld
	| scriptors |
	scriptors _ (aWorld allMorphs select:
		[:m | (((m isKindOf: ScriptEditorMorph) and: [m playerScripted == self]) and: [m scriptName == aSelector])] thenCollect: [:m | m topEditor]) asSet.
	^ scriptors asArray