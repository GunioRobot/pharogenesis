colorsAtCorners
	| c c14 c23 |
	c _ self color.
	c14 _ c lighter. c23 _ c darker.
	^Array with: c23 with: c14 with: c14 with: c23.