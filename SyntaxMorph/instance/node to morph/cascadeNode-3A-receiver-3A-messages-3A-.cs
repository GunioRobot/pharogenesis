cascadeNode: aNode receiver: receiver messages: messages
	| row |

	self alansTest1 ifTrue: [
		row _ self addColumn: #cascade on: aNode.
		row setSpecialOuterTestFormat.
	] ifFalse: [
		row _ self addRow: #cascade on: aNode
	].
	receiver asMorphicSyntaxIn: row.
	messages do: [:m | m asMorphicSyntaxIn: row].
	^ row

"	(node2 _ aNode copy) receiver: nil messages: messages.
	cascadeMorph _ row addColumn: #cascade2 on: node2.
	messages do: [ :m | m asMorphicSyntaxIn: cascadeMorph].
	^row
"
