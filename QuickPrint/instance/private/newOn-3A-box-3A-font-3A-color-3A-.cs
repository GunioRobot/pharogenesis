newOn: aForm box: aRectangle font: aStrikeFont color: textColor
	"Initialize myself."
	font _ aStrikeFont ifNil: [TextStyle default fontAt: 1].
	self setFont.
	destForm _ aForm.
	self colorMap: (Bitmap with: 0      "Assumes 1-bit deep fonts"
						with: ((textColor bitPatternForDepth: destForm depth) at: 1)).
	combinationRule _ Form paint.
	self clipRect: aRectangle.
	sourceY _ 0.
	kern _ 0.
	"sourceX is set when selecting the character from the font strike bitmap"
