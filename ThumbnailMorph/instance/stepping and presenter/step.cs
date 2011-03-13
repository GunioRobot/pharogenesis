step
	"Optimization: Don't redraw if we're viewing some kind of SketchMorph and its rotated Form hasn't changed."

	| viewee f |
	viewee := self actualViewee.
	viewee ifNil: [ self stopStepping. ^self ].
	(viewee isSketchMorph) ifTrue: [
		f := viewee rotatedForm.
		f == lastSketchForm ifTrue: [^ self].
		lastSketchForm := f].
	self changed.
