displayBitsOf: aForm Left: l Top: t Right: r Bottom: b 
	"Repaint the portion of the Smalltalk screen bounded by the 
	affected rectangle. Used to synchronize the screen after a 
	Bitblt to the Smalltalk Display object."
	| displayObj dispBits w h dispBitsIndex d left right top bottom surfaceHandle |
	displayObj _ self splObj: TheDisplay.
	aForm = displayObj ifFalse: [^ nil].
	self success: ((self isPointers: displayObj) and: [(self lengthOf: displayObj) >= 4]).
	successFlag
		ifTrue: [dispBits _ self fetchPointer: 0 ofObject: displayObj.
			w _ self fetchInteger: 1 ofObject: displayObj.
			h _ self fetchInteger: 2 ofObject: displayObj.
			d _ self fetchInteger: 3 ofObject: displayObj].
	successFlag ifFalse:[^nil].
	
	l < 0 ifTrue: [left _ 0] ifFalse: [left _ l].
	r > w ifTrue: [right _ w] ifFalse: [right _ r].
	t < 0 ifTrue: [top _ 0] ifFalse: [top _ t].
	b > h ifTrue: [bottom _ h] ifFalse: [bottom _ b].
	(left <= right and: [top <= bottom]) ifFalse: [^ nil].

	"if dispBits is a SmallInteger we are using an external platform bitmap as the display bits - call the SurfacePlugin to handle it"
	(self isIntegerObject: dispBits)
		ifTrue: [surfaceHandle _ self integerValueOf: dispBits.
			showSurfaceFn = 0
				ifTrue: [showSurfaceFn _ self ioLoadFunction: 'ioShowSurface' From: 'SurfacePlugin'.
					showSurfaceFn = 0
						ifTrue: [^ self success: false]].
			self cCode: '((int (*) (int, int, int, int, int))showSurfaceFn)(surfaceHandle, left, top, right-left, bottom-top)']
		ifFalse: [dispBitsIndex _ dispBits + BaseHeaderSize.
			self
				cCode: 'ioShowDisplay(dispBitsIndex, w, h, d, left, right, top, bottom)'
				inSmalltalk: [self showDisplayBits: dispBitsIndex w: w h: h d: d left: left right: right top: top bottom: bottom]]