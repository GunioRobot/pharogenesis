universalTilesForInterface: aMethodInterface
	"Return universal tiles for the given method interface.  Record who self is."

	| ms argTile itsSelector aType argList |
	itsSelector _ aMethodInterface selector.
	argList _ OrderedCollection new.
	aMethodInterface argumentVariables doWithIndex:
		[:anArgumentVariable :anIndex | 
			argTile _ ScriptingSystem tileForArgType: (aType _ aMethodInterface typeForArgumentNumber: anIndex).
			argList add: (aType == #Player 
				ifTrue: [argTile actualObject]
				ifFalse: [argTile literal]).	"default value for each type"].

	ms _ MessageSend receiver: self selector: itsSelector arguments: argList asArray.
	^ ms asTilesIn: self class globalNames: (self class officialClass ~~ CardPlayer)
			"For CardPlayers, use 'self'.  For others, name it, and use its name."