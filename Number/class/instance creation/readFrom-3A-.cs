readFrom: stringOrStream 
	"Answer a number as described on aStream.  The number may
	include a leading radix specification, as in 16rFADE"
	| value base aStream sign |
	aStream _ (stringOrStream isString)
		ifTrue: [ReadStream on: stringOrStream]
		ifFalse: [stringOrStream].
	(aStream nextMatchAll: 'NaN') ifTrue: [^ Float nan].
	sign _ (aStream peekFor: $-) ifTrue: [-1] ifFalse: [1].
	(aStream nextMatchAll: 'Infinity') ifTrue: [^ Float infinity * sign].
	base _ 10.
	value _ Integer readFrom: aStream base: base.
	(aStream peekFor: $r)
		ifTrue: 
			["<base>r<integer>"
			(base _ value) < 2 ifTrue: [^self error: 'Invalid radix'].
			(aStream peekFor: $-) ifTrue: [sign _ sign negated].
			value _ Integer readFrom: aStream base: base].
	^ self readRemainderOf: value from: aStream base: base withSign: sign.