initialize
	"Make a new atom with a random position and velocity."

	super initialize.
	self extent: 8@7.
	self color: Color blue.
	self borderWidth: 0.
	self randomPositionIn: (0@0 corner: 300@300) maxVelocity: 10.
