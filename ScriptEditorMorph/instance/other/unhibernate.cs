unhibernate
	| ww |
	"Recreate my tiles from my method.  If I have new universal tiles."

	(ww _ self world) 
		ifNil: [playerScripted ifNil: [^ self].
			playerScripted isUniversalTiles ifFalse: [^ self]]
		ifNotNil: [
			(ww valueOfProperty: #universalTiles ifAbsent: [false]) ifFalse: [^ self]].

	self showSourceInScriptor. 
