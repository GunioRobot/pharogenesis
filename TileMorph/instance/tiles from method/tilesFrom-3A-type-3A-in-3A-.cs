tilesFrom: argNode type: selType in: aScriptor
	| argType |
	"for an argument or receiver"

	argType _ selType.
	(argNode isKindOf: LiteralNode) 
		ifTrue: [argType ifNil: [argType _ argNode literalValue basicType].
			^ (aScriptor playerScripted tileForArgType: argType)
					setLiteral: argNode literalValue]
		ifFalse: [^ TilePadMorph new tilesFrom: argNode in: aScriptor].
