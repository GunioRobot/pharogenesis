readFrom: stringOrStream base: base
	"Answer a number as described on aStream in the given number base."

	| aStream sign |
	aStream _ (stringOrStream isString)
		ifTrue: [ReadStream on: stringOrStream]
		ifFalse: [stringOrStream].
	(aStream nextMatchAll: 'NaN') ifTrue: [^ Float nan].
	sign _ (aStream peekFor: $-) ifTrue: [-1] ifFalse: [1].
	(aStream nextMatchAll: 'Infinity') ifTrue: [^ Float infinity * sign].
	^ self readRemainderOf: (Integer readFrom: aStream base: base)
			from: aStream base: base withSign: sign