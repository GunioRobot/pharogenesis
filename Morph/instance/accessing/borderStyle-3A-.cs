borderStyle: newStyle
	newStyle = self borderStyle ifFalse:[
		(self canDrawBorder: newStyle) ifFalse:[
			"Replace the suggested border with a simple one"
			^self borderStyle: (BorderStyle width: newStyle width color: (newStyle trackColorFrom: self) color)].
		self setProperty: #borderStyle toValue: newStyle.
		self changed].