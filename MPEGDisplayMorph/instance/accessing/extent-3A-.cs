extent: aPoint
	"Overridden to maintain movie aspect ratio."

	| scale |
	frameBuffer ifNil: [^ super extent: aPoint].
	scale := (aPoint x / frameBuffer width) max: (aPoint y / frameBuffer height).
	scale := scale max: (16 / frameBuffer width).
	super extent: (frameBuffer extent * scale) rounded.
