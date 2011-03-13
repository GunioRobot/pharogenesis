step
	"Optimization: Don't redraw if we're viewing some kind of SketchMorph and its rotated Form hasn't changed."

	| viewee f |
	viewee _ self actualViewee.
	(viewee isKindOf: SketchMorph) ifTrue: [
		f _ viewee rotatedForm.
		f == lastSketchForm ifTrue: [^ self].
		lastSketchForm _ f].
	self changed.
