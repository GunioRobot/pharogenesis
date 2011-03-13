readFrom: stringOrStream base: base
	"Answer a number as described on aStream in the given number base."
	| aStream |
	aStream _ (stringOrStream isMemberOf: String)
		ifTrue: [ReadStream on: stringOrStream]
		ifFalse: [stringOrStream].
	^ self readRemainderOf: (Integer readFrom: aStream base: base)
			from: aStream base: base