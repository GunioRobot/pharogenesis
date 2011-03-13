findSelection: aPoint 
	"Determine which selection is displayed in an area containing the point, 
	aPoint. Answer the selection if one contains the point, answer nil 
	otherwise."

	| trialSelection |
	(self clippingBox containsPoint: aPoint) ifFalse: [^nil].
	trialSelection _ aPoint y - list compositionRectangle top // list lineGrid + 1.
	topDelimiter == nil ifFalse: [trialSelection _ trialSelection - 1].
	(trialSelection < 1) | (trialSelection > self maximumSelection)
		ifTrue: [^ nil]
		ifFalse: [^ trialSelection]