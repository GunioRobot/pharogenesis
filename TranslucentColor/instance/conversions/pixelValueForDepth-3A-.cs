pixelValueForDepth: d
	"Return the pixel value for this color at the given depth. Translucency only works in RGB; this color will appear either opaque or transparent at all other depths."

	alpha = 0 ifTrue: [^ 0].
	^ super pixelValueForDepth: d