getCurrentColor
	| formExtent form c |
	c := Color colorFromPixelValue: color depth: Display depth.
	formExtent := 30@30" min: 10@ 10//(2+1@2)".  "compute this better"
	form := Form extent: formExtent depth: Display depth.
	form borderWidth: 5.
	form border: form boundingBox width: 4 fillColor: Color white.
	form fill: form boundingBox fillColor: c.

	^form