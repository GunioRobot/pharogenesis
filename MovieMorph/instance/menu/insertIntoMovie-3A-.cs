insertIntoMovie: evt

	| movies target |
	movies _
		(self world rootMorphsAt: evt hand targetOffset)
			select: [:m | ((m isKindOf: MovieMorph) or:
						 [m isKindOf: SketchMorph]) and: [m ~= self]].
	movies isEmpty ifTrue: [^ self].
	target _ movies first.
	(target isKindOf: SketchMorph) ifTrue: [
		target _ target replaceSelfWithMovie].
	movies first insertFrames: frameList.
	self delete.
