addLowerEdge: oldEdge fromFace: face
	"Add the lower edge (v1-v2) from the given face.
	Return the newly created edge."
	| index minorEdge xValue |
	xValue _ face vertex1 windowPosX.
	index _ added firstIndexForInserting: xValue.
	index _ added xValue: xValue from: index do:[:edge|
		(edge rightFace == nil and:[
			"See the comment in #addEdgesFromFace:at:"
			(edge vertex0 == face vertex1 and:[edge vertex1 == face vertex2]) or:[
			edge vertex0 rasterPos = face vertex1 rasterPos and:[
				edge vertex1 rasterPos = face vertex2 rasterPos]]]) ifTrue:[
				"Adjust the left or right edge of the face"
				face leftEdge == oldEdge
					ifTrue:[face leftEdge: edge]
					ifFalse:[face rightEdge: edge].
				edge rightFace: face.
				^edge
			].
	].
	"Need to add new edge.
	NOTE: index already points to the right point for insertion."
	minorEdge _ B3DPrimitiveEdge new.
	minorEdge v0: face vertex1 v1: face vertex2.
	minorEdge nLines = 0 ifTrue:[^self]. "Horizontal"
	"Adjust left/right edge of the face"
	face leftEdge == oldEdge
		ifTrue:[face leftEdge: minorEdge]
		ifFalse:[face rightEdge: minorEdge].
	minorEdge leftFace: face.
	minorEdge initializePass1.
	added add: minorEdge beforeIndex: index.
	^minorEdge