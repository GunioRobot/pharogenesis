arrowHeadFrom: prevPt to: newPt arrowSpec: anArrowSpec
	"Put an arrowhead on the pen stroke from oldPt to newPt"

	| pm af myColor finalPt delta |
	myColor _ self color.
	delta _ newPt - prevPt.
	delta r <= 2 "pixels" ifTrue: [^ self].
	finalPt _ newPt + (Point r: sourceForm width degrees: delta degrees).	"in same direction"
	pm _ PolygonMorph vertices: (Array with: prevPt asIntegerPoint with: finalPt asIntegerPoint)  
		color: myColor  "not used"
		borderWidth: sourceForm width borderColor: myColor.
	pm makeOpen; makeForwardArrow.
	anArrowSpec ifNotNil: [pm arrowSpec: anArrowSpec].
	af _ pm arrowForms first.
	"render it onto the destForm"
	(FormCanvas on: destForm "Display") stencil: af at: af offset + (1@1)
		color: myColor