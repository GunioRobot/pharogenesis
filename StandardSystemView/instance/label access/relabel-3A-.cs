relabel: aString 
	"A new string for the label.  Window is assumed to be active.
	Window will redisplay only if label bar has to grow."
	| oldRegion oldWidth |
	(model windowReqNewLabel: aString) ifFalse: [^ self].
	oldRegion _ self labelTextRegion.
	oldWidth _ self insetDisplayBox width.
	self label: aString.
	Display fill: ((oldRegion merge: self labelTextRegion) expandBy: 3@0)
			fillColor: self labelColor.
	self insetDisplayBox width = oldWidth
		ifTrue: [self displayLabelText; emphasizeLabel]
		ifFalse: [self uncacheBits; displayEmphasized].
