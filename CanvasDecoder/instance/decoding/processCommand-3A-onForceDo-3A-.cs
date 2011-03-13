processCommand: command  onForceDo: forceBlock
	| verb verbCode |
	command isEmpty ifTrue: [ ^self ].

	verb _ command first.
	verbCode := verb at: 1.

	verbCode = CanvasEncoder codeClip ifTrue: [ ^self setClip: command ].
	verbCode = CanvasEncoder codeTransform ifTrue: [ ^self setTransform: command ].
	verbCode = CanvasEncoder codeText ifTrue: [ ^self drawText: command ].
	verbCode = CanvasEncoder codeLine ifTrue: [ ^self drawLine: command ].
	verbCode = CanvasEncoder codeRect ifTrue: [ ^self drawRect: command ].
	verbCode = CanvasEncoder codeBalloonRect ifTrue: [ ^self drawBalloonRect: command ].
	verbCode = CanvasEncoder codeBalloonOval ifTrue: [ ^self drawBalloonOval: command ].
	verbCode = CanvasEncoder codeInfiniteFill ifTrue: [ ^self drawInfiniteFill: command ].

	verbCode = CanvasEncoder codeOval ifTrue: [ ^self drawOval: command ].
	verbCode = CanvasEncoder codeImage ifTrue: [ ^self drawImage: command ].
	verbCode = CanvasEncoder codeReleaseCache ifTrue: [ ^self releaseImage: command ].
	verbCode = CanvasEncoder codePoly ifTrue: [ ^self drawPoly: command ].
	verbCode = CanvasEncoder codeStencil ifTrue: [ ^self drawStencil: command ].
	verbCode = CanvasEncoder codeForce ifTrue: [ ^self forceToScreen: command withBlock: forceBlock ].
	verbCode = CanvasEncoder codeFont ifTrue: [ ^self addFontToCache: command ].
	verbCode = CanvasEncoder codeExtentDepth ifTrue: [ ^self extentDepth: command ].

self error: 'unknown command: ', command first.