from3DS: aDictionary
	"Initialize the receiver from a 3DS point light"
	| spotValues hotSpot fallOff |
	super from3DS: aDictionary.
	spotValues _ aDictionary at: #spot.
	target _ spotValues at: #target.
	hotSpot _ spotValues at: #hotspotAngle.
	self minAngle: hotSpot.
	fallOff _ spotValues at: #falloffAngle.
	self maxAngle: hotSpot + fallOff.