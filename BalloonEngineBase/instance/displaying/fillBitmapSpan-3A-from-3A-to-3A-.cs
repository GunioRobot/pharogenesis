fillBitmapSpan: bits from: leftX to: rightX
	"Fill the span buffer between leftEdge and rightEdge using the given bits.
	Note: We always start from zero - this avoids using huge bitmap buffers if the bitmap is to be displayed at the very far right hand side and also gives us a chance of using certain bitmaps (e.g., those with depth 32) directly."
	| x0 x1 x bitX colorMask colorShift baseShift fillValue |
	self inline: false.
	self var: #bits declareC:'int *bits'.

	x0 _ leftX.
	x1 _ rightX.
	bitX _ -1. "Hack for pre-increment"
	self aaLevelGet = 1 ifTrue:["Speedy version for no anti-aliasing"
		[x0 < x1] whileTrue:[
			fillValue _ (self cCoerce: bits to: 'int *') at: (bitX _ bitX + 1).
			spanBuffer at: x0 put: fillValue.
			x0 _ x0 + 1.
		].
	] ifFalse:["Generic version with anti-aliasing"
		colorMask _ self aaColorMaskGet.
		colorShift _ self aaColorShiftGet.
		baseShift _ self aaShiftGet.
		[x0 < x1] whileTrue:[
			x _ x0 >> baseShift.
			fillValue _ (self cCoerce: bits to: 'int *') at: (bitX _ bitX + 1).
			fillValue _ (fillValue bitAnd: colorMask) >> colorShift.
			spanBuffer at: x put: (spanBuffer at: x) + fillValue.
			x0 _ x0 + 1.
		].
	].
	x1 > self spanEndGet ifTrue:[self spanEndPut: x1].
	x1 > self spanEndAAGet ifTrue:[self spanEndAAPut: x1].