scriptorsForSelector: aSelector inWorld: aWorld
	"Answer, for the purpose of deletion, a list of all scriptor objects for the given selector that are associated with any member of the receiver's uniclass"

	| scriptors |
	aWorld ifNil: [^ OrderedCollection new].
	scriptors _ (aWorld allMorphs select:
		[:m | (((m isKindOf: ScriptEditorMorph) and: [m playerScripted class == self class]) and: [m scriptName == aSelector])] thenCollect: [:m | m topEditor]) asSet.
	^ scriptors asArray