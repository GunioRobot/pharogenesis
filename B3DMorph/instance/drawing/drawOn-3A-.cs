drawOn: aCanvas
	color ifNotNil:["aCanvas frameAndFillRectangle: self bounds fillColor: color borderWidth: 1 borderColor: Color black."
		aCanvas frameRectangle: self bounds color: self color].
	aCanvas render: self.
