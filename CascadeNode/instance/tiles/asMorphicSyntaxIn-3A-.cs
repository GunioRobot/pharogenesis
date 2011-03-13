asMorphicSyntaxIn: parent
	| row |

	row _ parent addRow: #cascade on: self.
	receiver asMorphicSyntaxIn: row.
	messages do: [:m | m asMorphicSyntaxIn: row].
	^ row

"	(node2 _ self copy) receiver: nil messages: messages.
	cascadeMorph _ row addColumn: #cascade2 on: node2.
	messages do: [ :m | m asMorphicSyntaxIn: cascadeMorph].
	^row
"
