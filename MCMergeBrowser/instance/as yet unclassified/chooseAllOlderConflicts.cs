chooseAllOlderConflicts
	conflicts do: [ :ea | ea chooseOlder ].
	self changed: #text; changed: #list.