revertScriptVersionFrom: anEditor installing: aSavedEditor
	"Replace anEditor with a brought-up-to-date version of aSavedEditor"

	| aPosition oldOwner |
	aPosition _ anEditor position.
	oldOwner _ anEditor topRendererOrSelf owner.
	anEditor delete.
	currentScriptEditor _ aSavedEditor bringUpToDate install.
	player costume viewAfreshIn: oldOwner showingScript: selector at: aPosition