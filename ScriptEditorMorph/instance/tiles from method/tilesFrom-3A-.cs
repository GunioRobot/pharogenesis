tilesFrom: parseTree
	"Fill myself with tiles to corresponding to an existing method.  parseTree is the MethodNode that is the top of a parse tree.  Or a BlockNode or MessageNode for ifTrue:ifFalse:."
	"ignore the method's arguments for now"

	| lineOfTiles list ignore ind | 
	list _ (parseTree isKindOf: MessageNode)
		ifFalse: [parseTree block statements]	"normal MethodNode or BlockNode"
		ifTrue: [Array with: parseTree].
	ind _ 0.
	list do: [:msgNode |
		ignore _ msgNode isKindOf: ReturnNode.	"^ self  Will have to allow this someday"
		(msgNode isKindOf: VariableNode) ifTrue: [
			msgNode key = 'nil' ifTrue: [ignore _ true]]. 
		ignore ifFalse: ["for now ignore the (^ self) statement"
			lineOfTiles _ Array with: (PhraseTileMorph new tilesFrom: msgNode in: self).
			self insertTileRow: lineOfTiles after: (ind _ ind + 1)
			]].