xxSuperclass: superclass format: format segment: segment

	"Set up fields like a class but with null methodDict"
	shadowSuper _ superclass.
	shadowMethodDict _ nil.
	shadowFormat _ format.
	imageSegment _ segment.
