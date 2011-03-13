getDistanceTo: aPlayer

	| dist |
	dist _ ((aPlayer x - self x) squared + (aPlayer y - self y) squared) sqrt.
	^ dist.
