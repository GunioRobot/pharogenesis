trackFlag
	"Read keyframes for a flag (hide)"
	
	| flag |
	flag := false.
	^self trackCollect: [:params|
		"@@: Still to do ..."
		"params == nil ifFalse:[self halt]."
		flag := flag not.
		log == nil ifFalse: [log print: flag].
		flag].