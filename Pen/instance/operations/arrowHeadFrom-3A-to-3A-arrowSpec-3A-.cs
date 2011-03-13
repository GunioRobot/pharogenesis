arrowHeadFrom: prevPt to: newPt arrowSpec: anArrowSpec 
	"Put an arrowhead on the pen stroke from oldPt to newPt"
	| pm af myColor finalPt delta |
	myColor := self color.
	delta := newPt - prevPt.
	delta r <= 2 ifTrue: 
		[ "pixels"
		^ self ].
	finalPt := newPt + (Point 
			r: sourceForm width
			degrees: delta degrees).	"in same direction"
	pm := PolygonMorph 
		vertices: (Array 
				with: prevPt asIntegerPoint
				with: finalPt asIntegerPoint)
		color: myColor
		borderWidth: sourceForm width
		borderColor: myColor.	"not used"
	pm
		makeOpen;
		makeForwardArrow.
	anArrowSpec ifNotNil: [ pm arrowSpec: anArrowSpec ].
	af := pm arrowForms first.
	"render it onto the destForm"
	(FormCanvas on: destForm) 
		stencil: af
		at: af offset + (1 @ 1)
		color: myColor	"Display"