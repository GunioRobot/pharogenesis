shadowForm
	"Return a form representing the 'shadow' of the receiver - e.g., all pixels that are occupied by the receiver are one, all others are zero."
	| canvas |
	canvas _ (Display defaultCanvasClass extent: bounds extent depth: 1)
				asShadowDrawingCanvas: Color black. "Color black represents one for 1bpp"
	canvas translateBy: bounds topLeft negated
		during:[:tempCanvas| self fullDrawOn: tempCanvas].
	^ canvas form offset: bounds topLeft
