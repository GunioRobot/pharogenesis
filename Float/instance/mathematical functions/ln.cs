ln
	"Answer the natural logarithm of the receiver.
	 Optional. See Object documentation whatIsAPrimitive."

	| expt n mant x div pow delta sum eps |
	<primitive: 58>

	"Taylor series"
	self <= 0.0 ifTrue: [self error: 'ln is only defined for x > 0.0'].

	"get a rough estimate from binary exponent"
	expt _ self exponent.
	n _ Ln2 * expt.
	mant _ self timesTwoPower: 0 - expt.

	"compute fine correction from mantinssa in Taylor series"
	"mant is in the range [0..2]"
	"we unroll the loop to avoid use of abs"
	x _ mant - 1.0.
	div _ 1.0.
	pow _ delta _ sum _ x.
	x _ x negated.  "x <= 0"
	eps _ Epsilon * (n abs + 1.0).
	[delta > eps] whileTrue: [
		"pass one: delta is positive"
		div _ div + 1.0.
		pow _ pow * x.
		delta _ pow / div.
		sum _ sum + delta.
		"pass two: delta is negative"
		div _ div + 1.0.
		pow _ pow * x.
		delta _ pow / div.
		sum _ sum + delta].

	^ n + sum

	"2.718284 ln 1.0"