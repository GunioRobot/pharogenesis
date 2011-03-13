revertToLastSavedTileVersionFor: anEditor
	"revert to the last saved tile version"

	formerScriptingTiles isEmptyOrNil ifFalse:
		[anEditor reinsertSavedTiles: formerScriptingTiles last second].
	isTextuallyCoded _ false