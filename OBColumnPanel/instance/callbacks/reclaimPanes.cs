reclaimPanes
	| old |
	old := columns size.
	[self okToReclaimPane] whileTrue: [self popColumn].
	^ old - columns size