rotation: aVector
	| xRot yRot zRot cosPitch sinPitch cosYaw sinYaw cosRoll sinRoll |

	xRot _ (aVector x) degreesToRadians.
	yRot _ (aVector y) degreesToRadians.
	zRot _ (aVector z) degreesToRadians.

	cosPitch _ xRot cos.
	sinPitch _ xRot sin.
	cosYaw _ yRot cos.
	sinYaw _ yRot sin.
	cosRoll _ zRot cos.
	sinRoll _ zRot sin.

	self a11: (cosRoll*cosYaw).
	self a12: (sinRoll*cosYaw).
	self a13: (sinYaw negated).

	self a21: ((cosRoll*sinYaw*sinPitch) - (sinRoll*cosPitch)).
	self a22: ((cosRoll*cosPitch) + (sinRoll*sinYaw*sinPitch)).
	self a23: (cosYaw*sinPitch).
	self a31: ((cosRoll*sinYaw*cosPitch) + (sinRoll*sinPitch)).
	self a32: ((sinRoll*sinYaw*cosPitch) - (cosRoll*sinPitch)).
	self a33: (cosYaw*cosPitch).

	^ self.
