setClip: command
	| clipRectEnc |
	clipRectEnc _ command at: 2.
	clipRect _ self class decodeRectangle: clipRectEnc