additionsToViewerCategoryGeometry
	"answer additions to the geometry viewer category"

	^ #(geometry 
		(
			(slot x   'The x coordinate' Number readWrite Player  getX   Player setX:)
			(slot y   'The y coordinate' Number readWrite Player  getY  Player setY:)
			(slot heading  'Which direction the object is facing.  0 is straight up' Number readWrite Player getHeading  Player setHeading:)

			(slot  scaleFactor 'The factor by which the object is magnified' Number readWrite Player getScaleFactor Player setScaleFactor:)
			(slot  left   'The left edge' Number readWrite Player getLeft  Player  setLeft:)
			(slot  right  'The right edge' Number readWrite Player getRight  Player  setRight:)
			(slot  top  'The top edge' Number readWrite Player getTop  Player  setTop:) 
			(slot  bottom  'The bottom edge' Number readWrite Player getBottom  Player  setBottom:) 
			(slot  length  'The length' Number readWrite Player getLength  Player  setLength:) 
			(slot  width  'The width' Number readWrite Player getWidth  Player  setWidth:)

			(slot headingTheta 'The angle, in degrees, that my heading vector makes with the positive x-axis' Number readWrite Player getHeadingTheta Player setHeadingTheta:)

			(slot distance 'The length of the vector connecting the origin to the object''s position' Number readWrite Player getDistance Player setDistance:)
			(slot theta 'The angle between the positive x-axis and the vector connecting the origin to the object''s position' Number readWrite Player getTheta Player setTheta: )
		)
	)


