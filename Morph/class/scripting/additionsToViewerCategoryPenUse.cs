additionsToViewerCategoryPenUse
	"Answer viewer additions for the 'pen use' category"

	^#(
		#'pen use' 
		(
			(slot penColor 'the color of ink used by the pen' Color readWrite Player getPenColor Player setPenColor:) 
			(slot penSize 'the width of the pen' Number readWrite Player getPenSize Player setPenSize:) 
			(slot penDown 'whether the pen is currently down' Boolean readWrite Player getPenDown Player setPenDown:)
			(slot trailStyle 'determines whether lines, arrows, arrowheads, or dots are used when I put down a pen trail' TrailStyle readWrite Player getTrailStyle Player setTrailStyle:)
			(slot dotSize 'diameter of dot to use when trailStyle is dots' Number readWrite Player getDotSize Player setDotSize:)
			(command clearOwnersPenTrails 'clear all pen trails in my containing playfield')
		)
	)
