ceaseHavingAParameterFor: aSelector
	"Make the script represented by aSelector cease bearing a parameter"

	| newSel |
	self renameScript: aSelector newSelector: (newSel _ (aSelector copyWithout: $:) asSymbol).

	(self scriptEditorFor: newSel) assureParameterTilesValid; install