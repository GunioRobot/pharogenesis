initialize
	"CanvasDecoder initialize"
	"Set up my cache and decode table if necessary."
	CachedForms ifNil: [CachedForms := Array new: 100].
	DecodeTable ifNotNil: [ ^self ].

	DecodeTable _ Array new: 128.
	#((codeClip setClip:)
	(codeTransform setTransform:)
	(codeText drawText:)
	(codeLine drawLine:)
	(codeRect drawRect:)
	(codeBalloonRect drawBalloonRect:)
	(codeBalloonOval drawBalloonOval:)
	(codeInfiniteFill drawInfiniteFill:)
	(codeOval drawOval:)
	(codeImage drawImage:)
	(codeReleaseCache releaseImage:)
	(codePoly drawPoly:)
	(codeStencil drawStencil:)
	(codeForce forceToScreen:)
	(codeFont addFontToCache:)
	(codeTTCFont addTTCFontToCache:)
	(codeExtentDepth extentDepth:)
	(codeShadowColor shadowColor:))
		do: [ :arr |
			DecodeTable
				at: ((CanvasEncoder perform: arr first) asciiValue + 1)
				put: arr second
		].
