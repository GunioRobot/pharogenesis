radiansToDegrees: radians

	| degrees deg |
	degrees _ radians / 0.0174532925199433.
	deg _ 90.0 - degrees.
	deg > 0.0 ifFalse: [deg _ deg + 360.0].
	^ deg.

