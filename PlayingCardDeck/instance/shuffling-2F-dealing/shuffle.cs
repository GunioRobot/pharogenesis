shuffle

	submorphs _ submorphs shuffledBy: (Random new seed: seed).
	self layoutChanged.