trackRotation
	"Read keyframes interpolating a rotation"
	
	| angle axis |
	^self trackCollect: [:params|
		"@@: Still to do ..."
		"params == nil ifFalse:[self halt]."
		angle := self float.
		axis := self vector3.
		log == nil ifFalse: [log print: axis; space; print: angle radiansToDegrees].
		B3DRotation radiansAngle: angle negated axis: axis].