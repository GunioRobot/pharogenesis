dispatchID: id in: dispatcher
	"Look for id in dispatcher, and process it, if found"

	| index sel result |
	(index := self findID: id in: dispatcher) isNil ifTrue: [^nil].
	sel := self getSelectorFor: index in: dispatcher.
	indent := indent + 1.
	result := self perform: sel. 
	indent := indent - 1.
	result == nil ifTrue: [^nil].
	^self makeResult: result for: index in: dispatcher.