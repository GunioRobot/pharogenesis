universalTilesForInterface: aMethodInterface
	"Return universal tiles for the given method interface.  Record who self is."

	| ms argTile itsSelector aType argList makeSelfGlobal phrase |
	itsSelector _ aMethodInterface selector.
	argList _ OrderedCollection new.
	aMethodInterface argumentVariables doWithIndex:
		[:anArgumentVariable :anIndex | 
			argTile _ ScriptingSystem tileForArgType: (aType _ aMethodInterface typeForArgumentNumber: anIndex).
			argList add: (aType == #Player 
				ifTrue: [argTile actualObject]
				ifFalse: [argTile literal]).	"default value for each type"].

	ms _ MessageSend receiver: self selector: itsSelector arguments: argList asArray.
	"For CardPlayers, use 'self'.  For others, name me, and use my global name."
	makeSelfGlobal _ self class officialClass ~~ CardPlayer.
	phrase _ ms asTilesIn: self class globalNames: makeSelfGlobal.
	makeSelfGlobal ifFalse: [phrase setProperty: #scriptedPlayer toValue: self].
	^ phrase
