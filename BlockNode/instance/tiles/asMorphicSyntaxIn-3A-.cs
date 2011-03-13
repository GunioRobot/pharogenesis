asMorphicSyntaxIn: parent

	| row column |
	(column _ parent addColumn: #block on: self) layoutInset: 2@-1.
	self addCommentToMorph: column.
	arguments size > 0 ifTrue:
		[row _ column addRow: #blockarg1 on: (BlockArgsNode new).
		arguments do: [:arg | (arg asMorphicSyntaxIn: row) color: #blockarg2]].
	statements do: [ :each | 
		(each asMorphicSyntaxIn: column) borderWidth: 1.
		each addCommentToMorph: column].
	^ column