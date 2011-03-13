newScriptEditorFor: aSelector usingPhraseTile: aPhraseTileMorph
	"Sprout a scriptor for aSelector, using aPhraseTileMorph as its initial phrase."

	| aUserScript aScriptEditor |
	(self class selectors includes: aSelector) ifTrue: [self error: 'selector already exists'].

	aUserScript _ self class permanentUserScriptFor: aSelector player: self.
	aScriptEditor _ aUserScript instantiatedScriptEditor.
	aPhraseTileMorph ifNotNil: [aScriptEditor phrase: aPhraseTileMorph].
	aScriptEditor install.
	aPhraseTileMorph ifNil: [aScriptEditor showSourceInScriptor].
	self class allSubInstancesDo: [:anInst | anInst scriptInstantiationForSelector: aUserScript selector].
		"The above assures the presence of a ScriptInstantiation for the new selector in all siblings"

	self updateAllViewersAndForceToShow: #scripts.
	^ aScriptEditor