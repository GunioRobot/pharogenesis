viewAfreshIn: aPasteUp showingScript: aScriptName at: aPosition
	| anEditor |
	self player updateAllViewersAndForceToShow: 'scripts'.
	anEditor _ self player scriptEditorFor: aScriptName.
	aPasteUp ifNotNil: [aPasteUp addMorph: anEditor].
	anEditor position: aPosition