initialize    "SystemTracer initialize"
	"These consts are negative, so they will not match any oop.
	It is important, though, that UnassignedOop, at least, have
	zero in its low-order 2 bits, (like all oops) so that the use of +
	to merge the header type bits (happens in new:class:...) will
	not do weird things."
	Clamped _ -4.  "Flag clamped objects in oopMap"	
	UnassignedOop _ -8.  "Flag unassigned oops in oopMap"