trackColor
	"Read keyframes interpolating a color"
	
	| color |
	^self trackCollect: [:params|
		"@@: Still to do ..."
		"params == nil ifFalse:[self halt]."
		color := self colorFloat.
		log == nil ifFalse: [log print: color].
		color].