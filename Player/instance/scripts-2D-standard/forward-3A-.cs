forward: dist 
	"Move forward (viz. in the direction of my heading) by the given amount"

	| rho radians delta didStray p aCostume |
	(aCostume _ self costume) isInWorld ifFalse: [^ self].
	aCostume isWorldOrHandMorph ifTrue: [^ self].

	rho _ (aCostume asNumber: dist) asFloat.
	radians _ (self getHeadingUnrounded asFloat - 90.0) degreesToRadians.
	delta _ (radians cos @ radians sin) * rho.

	((aCostume owner isHandMorph not) and:
	 [aCostume owner fenceEnabled]) ifTrue:
		[(aCostume owner bounds containsRect: aCostume bounds) ifFalse:
			["If I stray out of the bounds of my owner, pull me back, but
			 without changing my heading as bounce would. Do nothing if
			 bounce has already corrected the direction."
			didStray _ false.
			((aCostume left < aCostume owner left and: [delta x < 0]) or:
			 [aCostume right > aCostume owner right and: [delta x > 0]]) ifTrue: [
				delta _ delta x negated @ delta y.
				didStray _ true].
			((aCostume top < aCostume owner top and: [delta y < 0]) or:
			 [aCostume bottom > aCostume owner bottom and: [delta y > 0]]) ifTrue: [
				delta _ delta x @ delta y negated.
				didStray _ true].
			didStray ifTrue: [aCostume makeFenceSound]]].

	"use and record the fractional position"
	p _ aCostume referencePosition + delta.
	aCostume referencePosition: p.
