chooseAllNewerConflicts
	conflicts do: [ :ea | ea chooseNewer ].
	self changed: #text; changed: #list.