quickPrintOn: aForm box: aRectangle font: aStrikeFont color: textColor
	"Initialize myself."
	bitBlt _ BitBlt current toForm: aForm.
	backgroundColor _ Color transparent.
	paragraphColor _ textColor.
	font _ aStrikeFont ifNil: [TextStyle defaultFont].
	emphasisCode _ 0.
	kern _ 0.
	indentationLevel _ 0.
	self setFont.
	"Override cbrule and map"
	bitBlt combinationRule: Form paint.
	bitBlt colorMap: (Bitmap with: 0      "Assumes 1-bit deep fonts"
						with: (textColor pixelValueForDepth: bitBlt destForm depth)).
	bitBlt clipRect: aRectangle.