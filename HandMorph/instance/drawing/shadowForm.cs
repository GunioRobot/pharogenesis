shadowForm
	"Return a 1-bit shadow of my submorphs.  Assumes submorphs is not empty"
	| bnds canvas |
	bnds _ Rectangle merging: (submorphs collect: [:m | m bounds]).
	canvas _ (Display defaultCanvasClass extent: bnds extent depth: 1) 
		asShadowDrawingCanvas: Color black.
	canvas translateBy: bnds topLeft negated
		during:[:tempCanvas| self drawSubmorphsOn: tempCanvas].
	^ canvas form offset: bnds topLeft