primitiveDeflateUpdateHashTable
	"Primitive. Update the hash tables after data has been moved by delta."
	| delta table tableSize tablePtr entry |
	self export: true.
	self var: #tablePtr declareC:'int *tablePtr'.
	interpreterProxy methodArgumentCount = 2
		ifFalse:[^interpreterProxy primitiveFail].
	delta _ interpreterProxy stackIntegerValue: 0.
	table _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	(interpreterProxy isWords: table)
		ifFalse:[^interpreterProxy primitiveFail].
	tableSize _ interpreterProxy slotSizeOf: table.
	tablePtr _ interpreterProxy firstIndexableField: table.
	0 to: tableSize-1 do:[:i|
		entry _ tablePtr at: i.
		entry >= delta
			ifTrue:[tablePtr at: i put: entry - delta]
			ifFalse:[tablePtr at: i put: 0]].
	interpreterProxy pop: 2. "Leave rcvr on stack"