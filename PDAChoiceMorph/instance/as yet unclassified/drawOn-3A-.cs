drawOn: aCanvas

	| offset |
	offset _ 4@(bounds height - self fontToUse height // 2).
	aCanvas frameAndFillRectangle: bounds fillColor: backgroundColor
			borderWidth: 1 borderColor: Color black.
	aCanvas text: contents
			bounds: ((bounds translateBy: offset) intersect: bounds)
			font: self fontToUse color: Color black.
