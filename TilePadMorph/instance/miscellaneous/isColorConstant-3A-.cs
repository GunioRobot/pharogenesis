isColorConstant: aParseNode
	"Is this a Color constant, of the form (MessageNode (VariableNode Color->Color) (SelectorNode #r:g:b:) (LiteralNode LiteralNode LiteralNode))"

	| rec |
	((rec _ aParseNode receiver) isKindOf: VariableNode) ifFalse: [^ false].
	rec key class == Association ifFalse: [^ false].
	rec key value == Color ifFalse: [^ false].
	aParseNode selector key == #r:g:b: ifFalse: [^ false].
	aParseNode arguments  size = 3 ifFalse: [^ false].
	^ true
