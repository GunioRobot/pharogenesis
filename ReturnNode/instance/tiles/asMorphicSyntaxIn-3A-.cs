asMorphicSyntaxIn: parent

	| row |
	row _ parent addRow: #return on: self.
	row addToken: '^ ' type: #assignment on: self.
	expr asMorphicSyntaxIn: row.
	expr addCommentToMorph: row.
	^row
