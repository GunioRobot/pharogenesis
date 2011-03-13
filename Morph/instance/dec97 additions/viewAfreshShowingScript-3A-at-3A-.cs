viewAfreshShowingScript: aScriptName at: aPosition
	| anEditor |
	costumee updateAllViewers.
	self world addMorph: (anEditor _ costumee scriptEditorFor: aScriptName).
	anEditor position: aPosition