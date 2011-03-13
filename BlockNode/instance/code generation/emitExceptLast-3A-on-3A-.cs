emitExceptLast: stack on: aStream
	| nextToLast |
	nextToLast _ statements size - 1.
	nextToLast < 1 ifTrue: [^ self].  "Only one statement"
	1 to: nextToLast - 1 do:
		[:i | (statements at: i) emitForEffect: stack on: aStream].
	(returns  "Don't pop before a return"
			and: [(statements at: nextToLast) prefersValue])
		ifTrue: [(statements at: nextToLast) emitForValue: stack on: aStream]
		ifFalse: [(statements at: nextToLast) emitForEffect: stack on: aStream]