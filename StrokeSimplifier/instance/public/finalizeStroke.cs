finalizeStroke
	"Finalize the current stroke, e.g., remove the last point(s) if necessary"
	| prevPt |
	prevPt _ lastPoint prevPoint.
	(prevPt prevPoint == nil or:[prevPt position = lastPoint position]) 
		ifFalse:[lastPoint _ prevPt].
	lastPoint nextPoint: nil.
	firstPoint do:[:pt| pt isFinal: true].