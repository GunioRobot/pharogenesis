bringUpToDate
	"Bring all versions of the receiver's tile-script source up to date"

	currentScriptEditor ifNotNil: [currentScriptEditor bringUpToDate].
	formerScriptingTiles isEmptyOrNil ifFalse:
		[formerScriptingTiles do:
			[:aPair | aPair second do:
				[:aMorph | (aMorph allMorphs select: [:s | s isTileScriptingElement]) do:
					[:el | el bringUpToDate]]]]