updateHash: piece at: square from: player 
	| index |
	index := player == whitePlayer ifTrue: [piece] ifFalse: [piece + 6].
	hashKey := hashKey bitXor: ((HashKeys at: index) at: square). 
	hashLock := hashLock bitXor: ((HashLocks at: index) at: square)