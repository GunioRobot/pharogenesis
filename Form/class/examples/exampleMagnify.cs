exampleMagnify

	| f m |
	f _ Form fromUser.
	m _ f magnify: f boundingBox by: 5 @ 5.
	m displayOn: Display at: Sensor waitButton

	"Form exampleMagnify."