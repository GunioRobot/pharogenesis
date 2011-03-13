allTileScriptingElements
	"Answer a list of all the morphs that pertain to tile-scripting.  A sledge-hammer"

	| all morphs |
	morphs _ IdentitySet new: 400.
	self allMorphsAndBookPagesInto: morphs.
	all _ morphs select: [:s | s isTileScriptingElement].
"	self closedViewerFlapTabs do:
		[:aTab | all addAll: aTab referent allTileScriptingElements].
"
	^ all asOrderedCollection