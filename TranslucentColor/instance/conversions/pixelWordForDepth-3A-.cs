pixelWordForDepth: depth
	"Return the pixel value for this color at the given depth. Translucency only works at a bit-depth of 32; this color will appear opaque at all other depths."

	| basicPixelWord |
	basicPixelWord _ super pixelWordForDepth: depth.
	depth < 32
		ifTrue: [^ basicPixelWord]
		ifFalse: [^ basicPixelWord bitOr: (alpha bitShift: 24)].
