sin
	"Answer the sine of the receiver taken as an angle in radians.
	 Optional. See Object documentation whatIsAPrimitive."

	| sum delta self2 i |
	<primitive: 56>

	"Taylor series"
	"normalize to the range [0..Pi/2]"
	self < 0.0 ifTrue: [^ (0.0 - ((0.0 - self) sin))].
	self > Twopi ifTrue: [^ (self \\ Twopi) sin].
	self > Pi ifTrue: [^ (0.0 - (self - Pi) sin)].
	self > Halfpi ifTrue: [^ (Pi - self) sin].

	"unroll loop to avoid use of abs"
	sum _ delta _ self.
	self2 _ 0.0 - (self * self).
	i _ 2.0.
	[delta > Epsilon] whileTrue: [
		"once"
		delta _ (delta * self2) / (i * (i + 1.0)).
		i _ i + 2.0.
		sum _ sum + delta.
		"twice"
		delta _ (delta * self2) / (i * (i + 1.0)).
		i _ i + 2.0.
		sum _ sum + delta].
	^ sum