asMorphicSyntaxIn: parent

	| row |

	row _ parent addRow: #literal on: self.
	(key isVariableBinding) ifFalse: [
		row layoutInset: 1.
		^ row addMorphBack: (row addString: key storeString special: false)].
	key key isNil ifTrue: [
		^ row addTextRow: ('###',key value soleInstance name)
	] ifFalse: [
		^ row addTextRow: ('##', key key)
	].	