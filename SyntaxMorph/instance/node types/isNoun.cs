isNoun
	"Consider these to be nouns:  TempVariableNode, LiteralNode, VariableNode, (MessageNode or CascadeNode with receiver), AssignmentNode"

	(#(TempVariableNode LiteralNode VariableNode AssignmentNode) includes:
		(parseNode class name)) ifTrue: [^ true].

	(self nodeClassIs: MessageNode) ifTrue: [^ parseNode receiver notNil].
	(self nodeClassIs: CascadeNode) ifTrue: [^ parseNode receiver notNil].

	^ false