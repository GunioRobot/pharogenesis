lookupBoard: aBoard
	| key entry |
	key _ aBoard hashKey bitAnd: array size - 1.
	entry _ array at: key + 1.
	entry ifNil:[^nil].
	entry valueType = -1 ifTrue:[^nil].
	entry hashLock = aBoard hashLock ifFalse:[^nil].
	^entry