updateHandles
	| midPts nextVertIx tweens newVert p2i |
	midPts _ OrderedCollection new.
	nextVertIx _ 2.
	tweens _ OrderedCollection new.
	self lineSegmentsDo:
		[:p1 :p2 | p2i _ p2 asIntegerPoint.
		tweens addLast: p2i.
		p2i = (vertices atWrap: nextVertIx) ifTrue:
			["Found endPoint."
			midPts addLast: (tweens at: tweens size // 2)
						+ (tweens at: tweens size + 1 // 2) // 2.
			tweens _ OrderedCollection new.
			nextVertIx _ nextVertIx + 1]].
	midPts withIndexDo:
		[:midPt :vertIndex |
		(closed or: [vertIndex < vertices size]) ifTrue:
			[newVert _ handles at: vertIndex*2.
			newVert position: midPt - (newVert extent // 2)]].