colorsFromArray: colorArray
	| colorList |
	colorList _ colorArray collect: [:colorDef |
		Color fromArray: colorDef].
	self colors: colorList