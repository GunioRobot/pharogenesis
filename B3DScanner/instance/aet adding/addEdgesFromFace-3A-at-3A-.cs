addEdgesFromFace: face at: yValue
	"Add the two top edges from the given face to the aet.
	The top edges are (v0-v1) and (v0-v2) where (v0-v1) is 
	the 'upper' half-edge of the triangle"
	| xValue index needMajor needMinor majorEdge minorEdge |
	face oneOverArea = 0.0 ifTrue:[^self].
	needMinor _ needMajor _ true. "We need both edges"
	majorEdge _ minorEdge _ nil.
	xValue _ face vertex0 windowPosX.
	"Search the insertion list to merge the edges of the face"
	index _ added firstIndexForInserting: xValue.
	index _ added xValue: xValue from: index do:[:edge|
		(edge rightFace == nil and:[
			"Note: edge vertex0 == face vertex0 should be the case for most meshes.
				But since it is advantegous for the scanner to have two faces per edge
				we're also checking for the actual vertex values."
			edge vertex0 == face vertex0 or:[
				edge vertex0 rasterPos = face vertex0 rasterPos]]) ifTrue:[
			"This edge is a possible candidate for adding the face"
			(needMajor and:["See above comment"
				edge vertex1 == face vertex2 or:[
					edge vertex1 rasterPos = face vertex2 rasterPos]]) ifTrue:[
				majorEdge _ edge.
				edge rightFace: face.
				edge flags: (edge flags bitOr: FlagEdgeRightMajor).
				nFaces _ nFaces + 1.
				needMinor ifFalse:[
					^self adjustFace: face major: majorEdge minor: minorEdge]. "Done."
				needMajor _ false.
			] ifFalse:[
				(needMinor and:["See above comment"
					edge vertex1 == face vertex1 or:[
						edge vertex1 rasterPos = face vertex1 rasterPos]]) ifTrue:[
					minorEdge _ edge.
					edge rightFace: face.
					edge flags: (edge flags bitOr: FlagContinueRightEdge).
					needMajor ifFalse:[
						^self adjustFace: face major: majorEdge minor: minorEdge]. "Done."
					needMinor _ false.
				].
			].
		].
	].
	"Need to add new edges.
	NOTE: index already points to the right point for insertion."
	needMajor ifTrue:[
		majorEdge _ B3DPrimitiveEdge new.
		majorEdge v0: face vertex0 v1: face vertex2.
		majorEdge nLines = 0 ifTrue:[^self]. "Horizontal edge"
		majorEdge leftFace: face.
		majorEdge initializePass1.
		majorEdge flags: (majorEdge flags bitOr: FlagEdgeLeftMajor).
		nFaces _ nFaces + 1.
	].
	needMinor ifTrue:[
		minorEdge _ B3DPrimitiveEdge new.
		minorEdge v0: face vertex0 v1: face vertex1.
		minorEdge leftFace: face.
		minorEdge flags: FlagContinueLeftEdge.

		"Note: If the (upper) minor edge is horizontal, use the lower one.
		Note: The lower minor edge cannot be horizontal if the major one isn't"
		minorEdge nLines = 0 ifTrue:[
			needMajor ifTrue:[added add: majorEdge beforeIndex: index].
			minorEdge _ self addLowerEdge: minorEdge fromFace: face.
			minorEdge nLines = 0 ifTrue:[self error:'Minor edge is horizontal'].
			^self adjustFace: face major: majorEdge minor: minorEdge].

		minorEdge flags: FlagContinueLeftEdge.
		minorEdge initializePass1.
		minorEdge xValue = xValue ifFalse:[self error:'Problem with minor edge'].
		minorEdge nLines = 0 ifTrue:[self error:'Minor edge is horizontal'].
	].
	needMajor & needMinor ifTrue:[
		added add: majorEdge and: minorEdge beforeIndex: index.
	] ifFalse:[
		needMajor
			ifTrue:[added add: majorEdge beforeIndex: index]
			ifFalse:[added add: minorEdge beforeIndex: index].
	].
	^self adjustFace: face major: majorEdge minor: minorEdge.