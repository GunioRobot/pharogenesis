displayString: aString from: startIndex to: stopIndex at: aPoint strikeFont: font kern: kernDelta
	destY _ aPoint y.
	destX _ aPoint x.
	^self primDisplayString: aString from: startIndex to: stopIndex
			map: font characterToGlyphMap xTable: font xTable
			kern: kernDelta.