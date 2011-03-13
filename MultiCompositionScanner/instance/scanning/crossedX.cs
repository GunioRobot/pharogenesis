crossedX
	"There is a word that has fallen across the right edge of the composition 
	rectangle. This signals the need for wrapping which is done to the last 
	space that was encountered, as recorded by the space stop condition."

	(breakAtSpace) ifTrue: [
		spaceCount >= 1 ifTrue:
			["The common case. First back off to the space at which we wrap."
			line stop: breakableIndex.
			presentationLine stop: breakableIndex - numOfComposition.
			lineHeight _ lineHeightAtBreak.
			baseline _ baselineAtBreak.
			spaceCount _ spaceCount - 1.
			breakableIndex _ breakableIndex - 1.

			"Check to see if any spaces preceding the one at which we wrap.
				Double space after punctuation, most likely."
			[(spaceCount > 1 and: [(text at: breakableIndex) = Space])]
				whileTrue:
					[spaceCount _ spaceCount - 1.
					"Account for backing over a run which might
						change width of space."
					font _ text fontAt: breakableIndex withStyle: textStyle.
					breakableIndex _ breakableIndex - 1.
					spaceX _ spaceX - (font widthOf: Space)].
			line paddingWidth: rightMargin - spaceX.
			presentationLine paddingWidth: rightMargin - spaceX.
			presentationLine internalSpaces: spaceCount.
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
			presentationLine paddingWidth: rightMargin - destX.
			presentationLine stop: (lastIndex max: line first).
			line stop: (lastIndex max: line first)].
		^true
	].

	(breakableIndex isNil or: [breakableIndex < line first]) ifTrue: [
		"Any breakable point in this line.  Just wrap last character."
		breakableIndex _ lastIndex - 1.
		lineHeightAtBreak _ lineHeight.
		baselineAtBreak _ baseline.
	].

	"It wasn't a space, but anyway this is where we break the line."
	line stop: breakableIndex.
	presentationLine stop: breakableIndex.
	lineHeight _ lineHeightAtBreak.
	baseline _ baselineAtBreak.
	^ true.
