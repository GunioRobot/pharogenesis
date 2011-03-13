readFrom: stringOrStream 
	"Answer a number as described on aStream.  The number may
	include a leading radix specification, as in 16rFADE"
	| value base aStream |
	aStream _ (stringOrStream isMemberOf: String)
		ifTrue: [ReadStream on: stringOrStream]
		ifFalse: [stringOrStream].
	base _ 10.
	value _ Integer readFrom: aStream base: 10.
	(aStream peekFor: $r)
		ifTrue: 
			["<base>r<integer>"
			(base _ value) < 2 ifTrue: [^self error: 'Invalid radix'].
			value _ Integer readFrom: aStream base: base].
	^ self readRemainderOf: value from: aStream base: base