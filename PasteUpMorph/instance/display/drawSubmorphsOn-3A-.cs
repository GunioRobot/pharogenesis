drawSubmorphsOn: aCanvas
	aCanvas clipBy: self innerBounds
			during:[:clippedCanvas| super drawSubmorphsOn: clippedCanvas].