drawOn: aCanvas
	text ifNil: [text _ 'Text' asText allBold].  "Default contents"
	"self drawBoundsOn: aCanvas."  "show line rects for debugging"
	self startingIndex > text size
	ifTrue:
		["make null text frame visible"
		aCanvas fillRectangle: bounds color: Color lightRed]
	ifFalse:
		[aCanvas newParagraph: self paragraph bounds: bounds color: color].