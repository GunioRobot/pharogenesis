modernizeScript
	"Invoked at user menu request to fix up an anonymous script editor"
	| oldSelector newSelector oldStatus aPosition oldOwner |
	oldSelector _ self scriptName.
	newSelector _ (oldSelector asString copyReplaceAll: 'xxxS' with: 's') asSymbol.

	oldStatus _ self scriptInstantiation status.
	scriptName _ newSelector.
	playerScripted class atSelector: scriptName putScriptEditor: self.
	self scriptInstantiation status: oldStatus.
	playerScripted class removeScriptNamed: oldSelector.
	playerScripted actorState instantiatedUserScriptsDictionary removeKey: oldSelector.
	submorphs first delete.  "the button row"
	self addMorphFront: self buttonRowForEditor.  "up to date"
	self install.
	aPosition _ self position.
	oldOwner _ self topRendererOrSelf owner.
	self delete
	playerScripted costume viewAfreshIn: oldOwner showingScript: scriptName at: aPosition