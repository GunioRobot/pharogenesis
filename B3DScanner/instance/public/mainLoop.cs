mainLoop
	| yValue nextObjY nextEdgeY obj activeStart passiveStart scaledY |
	objects size = 0 ifTrue:[^self]. "No input"
	self setupObjects. "Sort objects and create linked list"
	nFaces _ maxFaces _ maxEdges _ 0.
	"Pre-fetch first object to start from"
	activeStart _ passiveStart _ objects at: 1.
	yValue _ nextEdgeY _ nextObjY _ passiveStart bounds origin y.
	[activeStart == nil and:[passiveStart == nil and:[aet isEmpty]]] whileFalse:[
		"Add new objects if necessary"
		yValue = nextObjY ifTrue:[
			"Make sure we add edges from newly created objects"
			nextEdgeY _ nextObjY.
			"Add new objects"
			[passiveStart notNil and:[passiveStart bounds origin y = nextObjY]]
				whileTrue:[passiveStart _ passiveStart nextObj].
			passiveStart == nil 
				ifTrue:[nextObjY _ 99999]"Some large value"
				ifFalse:[nextObjY _ passiveStart bounds origin y]. 
		]. "End of adding new objects"

		"Add new edges if necessary"
		yValue = nextEdgeY ifTrue:[
			nextEdgeY _ nextObjY bitShift: 12. "Some VERY large value"
			scaledY _ (yValue+1) bitShift: 12.
			obj _ activeStart.
			[obj == passiveStart] whileFalse:[
				[obj atEnd not and:[obj peekY < scaledY]]
					whileTrue:[self addEdgesFromFace: obj next at: yValue].
				obj atEnd ifTrue:[
					obj == activeStart
						ifTrue:[activeStart _ obj nextObj]
						ifFalse:[obj prevObj nextObj: obj nextObj].
				] ifFalse:[obj peekY < nextEdgeY ifTrue:[nextEdgeY _ obj peekY]].
				obj _ obj nextObj.
			].
			nextEdgeY _ (nextEdgeY bitShift: -12).
		].
		added isEmpty ifFalse:[
			"Merge new edges into AET"
			"Note: These may be lower half edges."
			B3DScanner doDebug ifTrue:[self validateAETOrder].
			aet mergeEdgesFrom: added.
			B3DScanner doDebug ifTrue:[
				self validateAETOrder.
				self validateEdgesFrom: aet].
			added reset. "Clean up the list"
		].

		"This is the core loop."
		"[yValue < nextEdgeY and:[added isEmpty and:[aet isEmpty not]]] whileTrue:["
			B3DScanner doDebug ifTrue:[yValue printString displayAt: 0@0].
			"gather stats"
			maxEdges _ maxEdges max: aet size.
			maxFaces _ maxFaces max: nFaces.

			"Scan out the AET"
			aet isEmpty ifFalse:[
				self clearSpanBufferAt: yValue.
				self scanAETAt: yValue.
				self drawSpanBufferAt: yValue.

				"Advance to next y and update AET"
			].
			yValue _ yValue + 1.
			aet isEmpty ifFalse:[self updateAETAt: yValue].
		"]."
	].
	nFaces = 0 ifFalse:[self error: nFaces printString,' remaining faces'].