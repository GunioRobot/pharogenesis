forward: dist

	| rho radians delta didStray p fractionalP newP |
	costume isInWorld ifFalse: [^ self].
	costume isWorldOrHandMorph ifTrue: [^ self].

	rho _ (costume asNumber: dist) asFloat.
	radians _ (self getHeadingUnrounded asFloat - 90.0) degreesToRadians.
	delta _ (radians cos @ radians sin) * rho.

	((costume owner isHandMorph not) and:
	 [costume presenter fenceEnabled]) ifTrue:
		[(costume owner bounds containsRect: costume bounds) ifFalse:
			["If I stray out of the bounds of my owner, pull me back, but
			 without changing my heading as bounce would. Do nothing if
			 bounce has already corrected the direction."
			didStray _ false.
			((costume left < costume owner left and: [delta x < 0]) or:
			 [costume right > costume owner right and: [delta x > 0]]) ifTrue: [
				delta _ delta x negated @ delta y.
				didStray _ true].
			((costume top < costume owner top and: [delta y < 0]) or:
			 [costume bottom > costume owner bottom and: [delta y > 0]]) ifTrue: [
				delta _ delta x @ delta y negated.
				didStray _ true].
			didStray ifTrue: [costume makeFenceSound]]].

	"use and record the fractional position"
	p _ costume referencePosition asFloatPoint.
	fractionalP _ costume actorState fractionalPosition.
	(fractionalP == nil or: [(fractionalP - p) abs >= (1@1)])
		ifTrue: [newP _ p + delta]
		ifFalse: [newP _ p + (fractionalP - p) + delta].

	costume actorState fractionalPosition: newP.
	costume referencePosition: newP rounded.
