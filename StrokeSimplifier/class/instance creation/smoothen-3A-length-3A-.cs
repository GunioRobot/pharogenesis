smoothen: pointList length: unitLength
	| prevPt curPt nextPt out prevMid nextMid segment length steps deltaT |
	out _ WriteStream on: (Array new: pointList size).
	prevPt _ pointList at: pointList size-1.
	curPt _ pointList last.
	prevMid _ (curPt + prevPt) * 0.5.
	1 to: pointList size do:[:i|
		nextPt _ pointList at: i.
		nextMid _ (nextPt + curPt) * 0.5.
		segment _ Bezier2Segment from: prevMid to: nextMid via: curPt.
		length _ segment length.
		steps _ (length / unitLength) asInteger.
		steps < 1 ifTrue:[steps _ 1].
		deltaT _ 1.0 / steps.
		1 to: steps-1 do:[:k|
			out nextPut: (segment valueAt: deltaT * k)].
		out nextPut: nextMid.
		prevPt _ curPt.
		curPt _ nextPt.
		prevMid _ nextMid.
	].
	^out contents