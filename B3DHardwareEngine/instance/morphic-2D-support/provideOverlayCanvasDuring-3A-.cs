provideOverlayCanvasDuring: aBlock
	"Hand the sender a canvas that can be used for overlayed drawing.
	For now, we only provide one for renderers with direct frame buffer access.
	At some point I really want to revisit this scheme and use the overlay
	canvas for drawing the morphs in front but I don't have the time right now."
	target ifNil:[^self].
	target getCanvas translateBy: bufRect origin negated during: aBlock.