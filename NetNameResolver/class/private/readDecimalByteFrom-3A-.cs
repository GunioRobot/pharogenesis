readDecimalByteFrom: aStream
	"Read a positive, decimal integer from the given stream. Stop when a non-digit or end-of-stream is encountered. Return nil if stream is not positioned at a decimal digit or if the integer value read exceeds 255."

	| digitSeen value digit |
	digitSeen _ false.
	value _ 0.
	[aStream atEnd] whileFalse: [
		digit _ aStream next digitValue.
		(digit < 0 or: [digit > 9]) ifTrue: [
			aStream skip: -1.
			digitSeen ifFalse: [^ nil].
			^ value].
		digitSeen _ true.
		value _ (value * 10) + digit].
	(digitSeen and: [value <= 255]) ifFalse: [^ nil].
	value > 255 ifTrue: [^ nil].  "exceeds the range of a single byte integer"
	^ value
