bringUpToDate
	| newLabel |
	type == #objRef ifTrue:
		[newLabel _ actualObject externalName.
		self isPossessive ifTrue:
			[newLabel _ newLabel, '''s'].
		self line1: newLabel]
	