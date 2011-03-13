viewAfreshIn: aPasteUp showingScript: aScriptName at: aPosition
	"Obtain a smartly updated ScriptEditor for the given script name and zap it into place at aPosition"

	| anEditor |
	self player updateAllViewersAndForceToShow: #scripts.
	anEditor _ self player scriptEditorFor: aScriptName.
	aPasteUp ifNotNil: [aPasteUp addMorph: anEditor].
	anEditor position: aPosition.
	anEditor currentWorld startSteppingSubmorphsOf: anEditor