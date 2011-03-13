prepareForAlanDemo
	| aMorph |
	(aMorph _ self submorphNamed: 'Grab Screen Area') ifNotNil:
		[aMorph delete].
	(aMorph _ self submorphNamed: 'Flush') ifNotNil:
		[aMorph delete].
	self presenter flushViewerCache.
	self standardPalette ifNotNil:  [self standardPalette showNoPalette]