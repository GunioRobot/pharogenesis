rotateBy: angle about: center
	"Even though Point.theta is measured CW, this rotates with the more conventional CCW interpretateion of angle"
	| p r th |
	p _ self-center.
	r _ p r.
	th _ p theta negated.
	^ center + ((r * (th+angle) cos) @ (r * (th+angle) sin negated))