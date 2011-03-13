asMorphicSyntaxIn: parent

	| row |

	row _ parent addColumn: #literal on: self.
	(key isMemberOf: Association) ifFalse: [
		row layoutInset: 1.
		^ row addMorphBack: (row addString: key storeString)].
	key key isNil ifTrue: [
		^ row addTextRow: ('###',key value soleInstance name)
	] ifFalse: [
		^ row addTextRow: ('##', key key)
	].	