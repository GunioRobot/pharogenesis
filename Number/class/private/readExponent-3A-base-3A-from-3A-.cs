readExponent: baseValue base: base from: aStream
	"Complete creation of a number, reading exponent from aStream. Answer the
	number, or nil if parsing fails.
	<number>(e|d|q)<exponent>>"

	| sign exp value |
	aStream next. "skip e|d|q"
	sign _ ((aStream peek) == $-)
		ifTrue: [aStream next. -1]
		ifFalse: [1].
	(aStream peek digitValue between: 0 and: 9) ifFalse: [^ nil]. "Avoid throwing an error"
	exp _ (Integer readFrom: aStream base: 10) * sign.
	value := baseValue * (base raisedTo: exp).
	^ value
