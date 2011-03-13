patchOldTiles
	"EToySystem patchOldTiles"

	| s |
	TileMorph allSubInstances do:
		[:m | s _ m findA: StringMorph.
		s ifNotNil: [s font: ScriptingSystem fontForTiles.  s layoutChanged].
		m layoutChanged].

	EToyWorld allInstancesDo: [:w | w presenter flushViewerCache]