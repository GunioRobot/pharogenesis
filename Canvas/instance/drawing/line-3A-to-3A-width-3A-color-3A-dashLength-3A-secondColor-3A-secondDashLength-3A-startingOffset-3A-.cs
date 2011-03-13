line: pt1 to: pt2 width: width color: color1 dashLength: s1 secondColor: color2 secondDashLength: s2 startingOffset: startingOffset
	"Draw a line using the given width, colors and dash lengths.
	Originally written by Stephan Rudlof; tweaked by Dan Ingalls
	to use startingOffset for sliding offset as in 'ants' animations.
	Returns the sum of the starting offset and the length of this line."

	| dist deltaBig colors nextPhase segmentOffset phase segmentLength startPoint distDone endPoint segLens |
	dist _ pt1 dist: pt2.
	dist = 0 ifTrue: [^ startingOffset].
	s1 = 0 & (s2 = 0) ifTrue: [^ startingOffset].
	deltaBig _ pt2 - pt1.
	colors _ {color1. color2}.
	segLens _ {s1 asFloat. s2 asFloat}.
	nextPhase _ {2. 1}.

	"Figure out what phase we are in and how far, given startingOffset."
	segmentOffset _ startingOffset \\ (s1 + s2).
	segmentOffset < s1
		ifTrue: [phase _ 1.  segmentLength _ s1 - segmentOffset]
		ifFalse: [phase _ 2. segmentLength _ s1 + s2 - segmentOffset].
	startPoint _ pt1.
	distDone _ 0.0.

	[distDone < dist] whileTrue:
		[segmentLength _ segmentLength min: dist - distDone.
		endPoint _ startPoint + (deltaBig * segmentLength / dist).
		self line: startPoint truncated to: endPoint truncated
			width: width color: (colors at: phase).
		distDone _ distDone + segmentLength.
		phase _ nextPhase at: phase.
		startPoint _ endPoint.
		segmentLength _ segLens at: phase].

	^ startingOffset + dist