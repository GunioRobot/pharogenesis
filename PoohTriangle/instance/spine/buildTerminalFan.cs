buildTerminalFan
	| firstEdge pt points lastEdge nextEdge inside |
	self isTerminal ifFalse:[^self].
	e1 isBorderEdge ifFalse:[firstEdge _ e1. pt _ e3 origin].
	e2 isBorderEdge ifFalse:[firstEdge _ e2. pt _ e1 origin].
	e3 isBorderEdge ifFalse:[firstEdge _ e3. pt _ e2 origin].
	firstEdge ifNil:[^self].
	points _ OrderedCollection new.
	lastEdge _ firstEdge.
	points add: lastEdge destination; add: pt; add: lastEdge origin.
	nextEdge _  lastEdge leftFace oppositeSpineEdgeOf: lastEdge symmetric.
	[lastEdge rightFace isValid: false.
	nextEdge notNil and:[nextEdge fanVertices isNil]] whileTrue:[
		nextEdge origin = points first ifTrue:[
			points addLast: nextEdge destination
		] ifFalse:[nextEdge origin = points last ifTrue:[
			points addFirst: nextEdge destination.
		] ifFalse:[nextEdge destination = points first ifTrue:[
			points addLast: nextEdge origin.
		] ifFalse:[nextEdge destination = points last ifTrue:[
			points addFirst: nextEdge origin.
		] ifFalse:[self error:'I am confused']]]].
		inside _ nextEdge hasAllInsideCircle: points.
		lastEdge _ nextEdge.
		inside
			ifTrue:[nextEdge _ lastEdge leftFace oppositeSpineEdgeOf: lastEdge symmetric]
			ifFalse:[nextEdge _ nil].
	].
	lastEdge symmetric fanVertices: points.