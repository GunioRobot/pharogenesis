resetBoard

	self purgeAllCommands.
	self resetFreeCells;
		resetHomeCells;
		resetStacks;
		addHardness;
		changed.