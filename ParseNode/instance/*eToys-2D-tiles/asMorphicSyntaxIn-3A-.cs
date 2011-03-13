asMorphicSyntaxIn: parent

	| morph |
	"Default for missing implementations"

	morph := parent addColumn: #error on: self.
	morph addTextRow: self class printString.
	^morph
	

