insertIntoMovie: evt

	| movies aTarget |
	movies _
		(self world rootMorphsAt: evt hand targetOffset)
			select: [:m | ((m isKindOf: MovieMorph) or:
						 [m isSketchMorph]) and: [m ~= self]].
	movies isEmpty ifTrue: [^ self].
	aTarget _ movies first.
	(aTarget isSketchMorph) ifTrue:
		[aTarget _ aTarget replaceSelfWithMovie].
	movies first insertFrames: frameList.
	self delete.
