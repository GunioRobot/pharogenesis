vectorAdditions
	"Answer slot/command definitions for the vector experiment"

	^ # (
(slot x   'The x coordinate' Number readWrite Player  getX   Player setX:)
(slot y   'The y coordinate' Number readWrite Player  getY  Player setY:)
(slot heading  'Which direction the object is facing.  0 is straight up' Number readWrite Player getHeading  Player setHeading:)
(slot distance 'The length of the vector connecting the origin to the object''s position' Number readWrite Player getDistance Player setDistance:)
(slot theta 'The angle between the positive x-axis and the vector connecting the origin to the object''s position' Number readWrite Player getTheta Player setTheta: )
(slot headingTheta 'The angle that my heading vector makes with the positive x-axis' Number readWrite Player getHeadingTheta Player setHeadingTheta:)

(command + 'Adds two players together, treating each as a vector from the origin.' Player)
(command - 'Subtracts one player from another, treating each as a vector from the origin.' Player)
(command * 'Multiply a player by a Number, treating the Player as a vector from the origin.' Number)
(command / 'Divide a player by a Number, treating the Player as a vector from the origin.' Number)

(command incr: 'Each Player is a vector from the origin.  Increase one by the amount of the other.' Player)
(command decr: 'Each Player is a vector from the origin.  Decrease one by the amount of the other.' Player)
(command multBy: 'A Player is a vector from the origin.  Multiply its length by the factor.' Number)
(command dividedBy: 'A Player is a vector from the origin.  Divide its length by the factor.' Number)
	)