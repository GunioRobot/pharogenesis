arcTan
	"Answer the angle in radians.
	 Optional. See Object documentation whatIsAPrimitive."

	| theta eps step sinTheta cosTheta |
	<primitive: 57>

	"Newton-Raphson"
	self < 0.0 ifTrue: [ ^ 0.0 - (0.0 - self) arcTan ].

	"first guess"
	theta _ (self * Halfpi) / (self + 1.0).

	"iterate"
	eps _ Halfpi * Epsilon.
	step _ theta.
	[(step * step) > eps] whileTrue: [
		sinTheta _ theta sin.
		cosTheta _ theta cos.
		step _ (sinTheta * cosTheta) - (self * cosTheta * cosTheta).
		theta _ theta - step].
	^ theta