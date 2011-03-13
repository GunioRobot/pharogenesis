makeAllTilesGreen
	(self allMorphsAndBookPagesInto: Set new) do:
		[:m | m useUniformTileColor]