renameScript: newSelector
	| aPosition oldStatus existingOwner |
	oldStatus _ self scriptInstantiation status.
	"self titleMorph borderColor: Color black."
	scriptName _ newSelector.
	self scriptInstantiation status: oldStatus.
	submorphs first delete.  "the button row"
	self addMorphFront: self buttonRowForEditor.  "up to date"
	self install.
	aPosition _ self position.
	existingOwner _ self topRendererOrSelf owner.
	self delete.
	existingOwner ifNotNil:
		[playerScripted costume viewAfreshIn: existingOwner showingScript: scriptName at: aPosition]