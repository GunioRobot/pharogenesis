trackFloat
	"Read keyframes interpolating a float (hotspot, falloff, roll, etc.)"
	
	| float |
	^self trackCollect: [:params|
		"@@: Still to do ..."
		"params == nil ifFalse:[self halt]."
		float := self float.
		log == nil ifFalse: [log print: float].
		float].