sqrt
	"Answer the square root of the receiver.
	 Optional. See Object documentation whatIsAPrimitive."

	| exp guess eps delta |
	<primitive: 55>

	"Newton-Raphson"
	self <= 0.0 ifTrue: [
		self = 0.0
			ifTrue: [^ 0.0]
			ifFalse: [^ self error: 'sqrt is invalid for x < 0']].

	"first guess is half the exponent"
	exp _ self exponent // 2.
	guess _ self timesTwoPower: (0 - exp).

	"get eps value"
	eps _ guess * Epsilon.
	eps _ eps * eps.
	delta _ (self - (guess * guess)) / (guess * 2.0).
	[(delta * delta) > eps] whileTrue: [
		guess _ guess + delta.
		delta _ (self - (guess * guess)) / (guess * 2.0)].
	^ guess