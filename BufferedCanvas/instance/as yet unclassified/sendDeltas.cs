sendDeltas
"
NebraskaDebug showStats: #sendDeltas
"
	| t deltas dirtyFraction |

	previousVersion ifNil: [
		previousVersion _ Display deepCopy.
		remote 
			image: previousVersion 
			at: 0@0 
			sourceRect: previousVersion boundingBox 
			rule: Form paint.
		^remote forceToScreen: previousVersion boundingBox.
	].
	dirtyRect ifNil: [^self].
	t _ Time millisecondClockValue.
	dirtyFraction _ dirtyRect area / previousVersion boundingBox area roundTo: 0.0001.

	deltas _ mirrorOfScreen deltaFrom: (previousVersion copy: dirtyRect) at: dirtyRect origin.
	previousVersion _ mirrorOfScreen.
	mirrorOfScreen _ nil.

	remote 
		image: deltas at: dirtyRect origin sourceRect: deltas boundingBox rule: Form reverse;
		forceToScreen: dirtyRect.

	t _ Time millisecondClockValue - t.
	NebraskaDebug at: #sendDeltas add: {t. dirtyFraction. deltas boundingBox}.
	dirtyRect _ nil.
