step
	"Optimization: Don't redraw if we're viewing some kind of SketchMorph and its rotated Form hasn't changed."

	| viewee f |
	viewee _ self actualViewee.
	viewee ifNil: [ self stopStepping. ^self ].
	(viewee isSketchMorph) ifTrue: [
		f _ viewee rotatedForm.
		f == lastSketchForm ifTrue: [^ self].
		lastSketchForm _ f].
	self changed.
