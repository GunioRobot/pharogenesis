noteDeletionOf: aMorph
	| pal |
	aMorph == self morph ifTrue:
		[(pal _ self standardPalette)
			ifNotNil: [pal showNoPalette]
			ifNil:	[self delete]]   "Viewer on a discarded player"