insertIntoMovie: evt

	| movies aTarget |
	movies _
		(self world rootMorphsAt: evt hand targetOffset)
			select: [:m | ((m isKindOf: MovieMorph) or:
						 [m isKindOf: SketchMorph]) and: [m ~= self]].
	movies isEmpty ifTrue: [^ self].
	aTarget _ movies first.
	(aTarget isKindOf: SketchMorph) ifTrue: [
		aTarget _ aTarget replaceSelfWithMovie].
	aTarget insertFrames: (Array with: self).
	self delete.
