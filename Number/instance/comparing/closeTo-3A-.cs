closeTo: num
	"are these two numbers close?"

	| ans |
	num isFloat ifTrue: [^ num closeTo: self asFloat].
	[ans _ self = num] ifError: [:aString :aReceiver | ^ false].
	^ ans