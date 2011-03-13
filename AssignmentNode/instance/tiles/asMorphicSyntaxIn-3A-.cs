asMorphicSyntaxIn: parent

	| row |

	row _ parent addRow: #assignment on: self.
	variable asMorphicSyntaxIn: row.
	row addToken: ' _ ' type: #assignment on: self.
	value asMorphicSyntaxIn: row.
	^row
