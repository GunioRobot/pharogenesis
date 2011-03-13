flushUp: evt with: aMorph

	aMorph submorphCount > 0
		ifTrue: [aMorph firstSubmorph color: Color black].

	(aMorph containsPoint: evt cursorPoint)
		ifTrue:
			[aMorph primaryHand flushViewerCache.
			aMorph standardPalette ifNotNil: [aMorph standardPalette showNoPalette]]