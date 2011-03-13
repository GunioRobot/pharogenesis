buildingSystem
	"Should be true only during system building.  1/18/96 sw"

	BuildingSystem isNil ifTrue: [BuildingSystem _ false].
	^ BuildingSystem