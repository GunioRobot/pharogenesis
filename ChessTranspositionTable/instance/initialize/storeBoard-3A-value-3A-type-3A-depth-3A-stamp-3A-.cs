storeBoard: aBoard value: value type: valueType depth: depth stamp: timeStamp
	| key entry |
	key _ aBoard hashKey bitAnd: array size - 1.
	entry _ array at: key + 1.
	entry valueType = -1 
		ifTrue:[used nextPut: entry]
		ifFalse:[entry hashLock = aBoard hashLock ifFalse:[collisions _ collisions + 1]].
	(entry valueType = -1 
		or:[entry depth <= depth
		or:[entry timeStamp < timeStamp]]) ifFalse:[^self].
	entry hashLock: aBoard hashLock.
	entry value: value.
	entry valueType: valueType.
	entry depth: depth.
	entry timeStamp: timeStamp.
