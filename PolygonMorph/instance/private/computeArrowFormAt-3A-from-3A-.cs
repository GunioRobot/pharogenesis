computeArrowFormAt: endPoint from: priorPoint 
	"Compute a triangle oriented along the line from priorPoint to  
	endPoint. Then draw those lines in a form and return that  
	form, with appropriate offset"
	| p1 pts box arrowForm bb origin  |
	pts _ self arrowBoundsAt: endPoint from: priorPoint.
	box _ ((pts first rect: pts last)
				encompass: (pts at: 2))
				expandBy: 1.
	arrowForm _ Form extent: box extent asIntegerPoint.
	bb _ (BitBlt current toForm: arrowForm) sourceForm: nil;
				 fillColor: Color black;
				 combinationRule: Form over;
				 width: 1;
				 height: 1.
	origin _ box topLeft.
	p1 _ pts last - origin.
	pts
		do: [:p | 
			bb drawFrom: p1 to: p - origin.
			p1 _ p - origin].
	arrowForm convexShapeFill: Color black.
	^ arrowForm offset: box topLeft