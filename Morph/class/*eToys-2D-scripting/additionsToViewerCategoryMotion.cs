additionsToViewerCategoryMotion
	"Answer viewer additions for the 'motion' category"

	^#(
		motion 
		(
			(slot x 'The x coordinate' Number readWrite Player getX Player setX:)
			(slot y  	'The y coordinate' Number readWrite Player 	getY Player setY:)
			(slot heading  'Which direction the object is facing.  0 is straight up' Number readWrite Player getHeading Player setHeading:)
			(command forward: 'Moves the object forward in the direction it is heading' Number)
			(slot obtrudes 'whether the object sticks out over its container''s edge' Boolean readOnly Player getObtrudes unused unused) 
			(command turnToward: 'turn toward the given object' Player) 
			(command moveToward: 'move toward the given object' Player) 
			(command turn: 'Change the heading of the object by the specified amount' Number)
			(command bounce: 'bounce off the edge if hit' Sound) 
			(command wrap 'wrap off the edge if appropriate') 
			(command followPath 'follow the yellow brick road') 
			(command goToRightOf: 'place this object to the right of another' Player)
		)
	)

