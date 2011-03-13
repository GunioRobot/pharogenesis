exampleShrink

	| f s |
	f _ Form fromUser.
	s _ f shrink: f boundingBox by: 2 @ 5.
	s displayOn: Display at: Sensor waitButton	

	"Form exampleShrink."