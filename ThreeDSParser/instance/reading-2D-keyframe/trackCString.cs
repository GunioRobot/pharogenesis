trackCString
	"Read keyframes defining a string (morph)"
	
	| string |
	^self trackCollect: [:params|
		"@@: Still to do ..."
		"params == nil ifFalse:[self halt]."
		string := self cString.
		log == nil ifFalse: [log print: string].
		string].