allScriptsToolForActiveWorld
	"Launch an AllScriptsTool to view scripts of the active world"

	| aTool |
	aTool _ self newColumn.
	aTool initializeFor: ActiveWorld presenter.
	^ aTool