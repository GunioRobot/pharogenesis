pageHeight
	| howManyLines visibleHeight totalHeight ratio |
	howManyLines _ paragraph numberOfLines.
	visibleHeight _ self visibleHeight.
	totalHeight _ self totalTextHeight.
	ratio _ visibleHeight / totalHeight.
	^(ratio * howManyLines) rounded - 2