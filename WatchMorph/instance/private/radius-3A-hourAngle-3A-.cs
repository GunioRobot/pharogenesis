radius: unitRadius hourAngle: hourAngle
	"unitRadius goes from 0.0 at the center to 1.0 on the circumference.
	hourAngle runs from 0.0 clockwise around to 12.0 with wrapping."

	^ self center + (self extent * (Point r: 0.5 * unitRadius
									degrees: hourAngle * 30.0 - 90.0)).