insertIntoMovie: evt

	| movies aTarget |
	movies _
		(self world rootMorphsAt: evt hand targetPoint)
			select: [:m | ((m isKindOf: MovieMorph) or:
						 [m isSketchMorph]) and: [m ~= self]].
	movies isEmpty ifTrue: [^ self].
	aTarget _ movies first.
	(aTarget isSketchMorph) ifTrue: [
		aTarget _ aTarget replaceSelfWithMovie].
	aTarget insertFrames: (Array with: self).
	self delete.
