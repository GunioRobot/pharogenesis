cornerSetterFor: aPoint
	"Return the closest corner or center to aPoint.  For dragging its size or moving whole rectangle (like HyperCard button move)."
	| myCenter nearest nearPt |
	myCenter _ self center.
	nearest _ aPoint x > myCenter x
		ifTrue: [aPoint y > myCenter y 
			ifTrue: [3]
			ifFalse: [2]]
		ifFalse: [aPoint y > myCenter y 
			ifTrue: [4]
			ifFalse: [1]].
	nearPt _ self perform: 
		(#(topLeft topRight bottomRight bottomLeft) at: nearest).
	(aPoint dist: myCenter) < (aPoint dist: nearPt) 
		ifTrue: [^ #center:]
		ifFalse: [^ #(topLeft: topRight: bottomRight: bottomLeft:) at: nearest].

	false ifTrue: ["Selectors Performed"
		"Please list all selectors that could be args to the 
		perform: in this method.  Do this so senders will find
		this method as one of the places the selector is sent from."
		self listPerformSelectorsHere.		"tells the parser its here"

		self bottomRight. self topRight.
		self bottomLeft. self topLeft.
		self center.
		].