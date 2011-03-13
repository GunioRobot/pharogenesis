hibernate
	"Possibly delete the tiles."

	| ww |
	(ww _ self world) 
		ifNil: [(playerScripted == nil or: [playerScripted isUniversalTiles]) ifFalse: [^ self]]
		ifNotNil:
			[(ww valueOfProperty: #universalTiles ifAbsent: [false]) ifFalse: [^ self]].

	submorphs size > 1 ifTrue: [submorphs second delete].