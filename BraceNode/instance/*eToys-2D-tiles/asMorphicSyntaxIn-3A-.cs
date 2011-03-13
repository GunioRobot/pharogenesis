asMorphicSyntaxIn: parent

	| row |

	row _ (parent addRow: #brace on: self) layoutInset: 1.
	row addMorphBack: (StringMorph new contents: 
		(String streamContents: [:aStream | self printOn: aStream indent: 0])).
	^row
