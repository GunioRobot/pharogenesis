scanAETAt: yValue
	"Scan out and draw the active edge table"
	| leftEdge rightEdge tmp |
	aet reset.
	aet atEnd ifTrue:[^nil].

	"Note the following is debug code that allows restarting this method
	without getting confused by the face flags. In release mode, having
	faces in the fillList here would be either an error or due to clipping
	at the right boundary."
	fillList do:[:face| face flags: (face flags bitXor: FlagFaceActive)].
	fillList reset.

	nextIntersection xValue: 16r3FFFFFFF. "Out of reach"
	leftEdge _ aet next.
	"No do the AET scan"
	[aet atEnd] whileFalse:[
		"The left edge here is always a top edge. Toggle its fills."
		self toggleTopFillsOf: leftEdge at: yValue.
		"After we got a new top face we have to adjust possible intersections."
		self adjustIntersectionsAt: yValue from: leftEdge. 
		"Search for the next top edge, which will be the right boundary."
		rightEdge _ self searchForNewTopEdgeFrom: leftEdge at: yValue.
		"And fill the stuff"
		self fillFrom: leftEdge to: rightEdge at: yValue.

		leftEdge _ rightEdge.
		"Use a new intersection edge if necessary"
		leftEdge == nextIntersection ifTrue:[
			tmp _ nextIntersection.
			nextIntersection _ lastIntersection.
			lastIntersection _ tmp].
		nextIntersection xValue: 16r3FFFFFFF "Must be waaaay off to the right ;-)"
	].
	self toggleBackFillsOf: leftEdge at: yValue validate: false.
	fillList isEmpty ifFalse:[self error:'FillList not empty'].