makeAllTilesColored
	(self allMorphsAndBookPagesInto: Set new) do:
		[:m | m restoreTypeColor]