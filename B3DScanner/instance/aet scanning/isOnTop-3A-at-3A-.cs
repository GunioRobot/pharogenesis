isOnTop: edge at: yValue
	"Return true if the edge is on top of the current front face"
	| topFace floatX floatY |
	topFace _ fillList first.
	topFace == nil ifTrue:[^true].
	"Note: It is important to return true if the edge is shared by the top face"
	(edge leftFace == topFace or:[edge rightFace == topFace]) ifTrue:[^true].
	floatX _ edge xValue / 4096.0.
	floatY _ yValue.
	^edge zValue < (fillList first zValueAtX: floatX y:  floatY).