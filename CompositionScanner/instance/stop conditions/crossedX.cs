crossedX
	"There is a word that has fallen across the right edge of the composition 
	rectangle. This signals the need for wrapping which is done to the last 
	space that was encountered, as recorded by the space stop condition."

	spaceCount >= 1 ifTrue:
		["The common case. First back off to the space at which we wrap."
		line stop: spaceIndex.
		lineHeight _ lineHeightAtSpace.
		baseline _ baselineAtSpace.
		spaceCount _ spaceCount - 1.
		spaceIndex _ spaceIndex - 1.

		"Check to see if any spaces preceding the one at which we wrap.
			Double space after punctuation, most likely."
		[(spaceCount > 1 and: [(text at: spaceIndex) = Space])]
			whileTrue:
				[spaceCount _ spaceCount - 1.
				"Account for backing over a run which might
					change width of space."
				font _ text fontAt: spaceIndex withStyle: textStyle.
				spaceIndex _ spaceIndex - 1.
				spaceX _ spaceX - (font widthOf: Space)].
		line paddingWidth: rightMargin - spaceX.
		line internalSpaces: spaceCount]
	ifFalse:
		["Neither internal nor trailing spaces -- almost never happens."
		lastIndex _ lastIndex - 1.
		[destX <= rightMargin]
			whileFalse:
				[destX _ destX - (font widthOf: (text at: lastIndex)).
				lastIndex _ lastIndex - 1].
		spaceX _ destX.
		line paddingWidth: rightMargin - destX.
		line stop: (lastIndex max: line first)].
	^true