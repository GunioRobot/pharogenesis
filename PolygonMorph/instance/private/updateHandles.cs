updateHandles
	| newVert oldVert |
	vertices withIndexDo:
		[:vertPt :vertIndex |
		oldVert _ handles at: vertIndex*2-1.
		oldVert position: vertPt - (oldVert extent//2).
		(closed or: [vertIndex < vertices size]) ifTrue:
			[newVert _ handles at: vertIndex*2.
			newVert position: (vertPt + (vertices atWrap: vertIndex+1)
								- newVert extent) // 2 + (1@-1)]].