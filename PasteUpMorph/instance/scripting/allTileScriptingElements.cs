allTileScriptingElements
	^ self allMorphs select:
		[:s | s isTileScriptingElement]