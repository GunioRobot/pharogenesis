additionsToViewerCategoryBasic
	"Answer viewer additions for the 'basic' category"

	^#(
		basic 
		(
			(slot x 'The x coordinate' Number readWrite Player getX Player setX:)
			(slot y  	'The y coordinate' Number readWrite Player 	getY Player setY:)
			(slot heading  'Which direction the object is facing.  0 is straight up' Number readWrite Player getHeading Player setHeading:)
			(command forward: 'Moves the object forward in the direction it is heading' Number)
			(command turn: 'Change the heading of the object by the specified amount' Number)
			(command beep: 'Make the specified sound' Sound)
		)
	)
