drawOn: aCanvas

	hasFocus ifTrue: [aCanvas fillRectangle: self bounds color: Color yellow].
	aCanvas text: contents bounds: bounds font: font color: color.