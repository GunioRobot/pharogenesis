composeLinesFrom: startingIndex withLines: startingLines atY: startingY
	| charIndex lineY lineHeight scanner line row firstLine lineHeightGuess saveCharIndex hitCR |
	charIndex _ startingIndex.
	lines _ startingLines.
	lineY _ startingY.
	lineHeightGuess _ textStyle lineGrid.
	maxRightX _ container left.
	scanner _ CompositionScanner new text: text textStyle: textStyle.
	firstLine _ true.
	[charIndex <= text size and: [(lineY + lineHeightGuess) <= container bottom]]
		whileTrue:
		[lineHeight _ lineHeightGuess.
		saveCharIndex _ charIndex.
		hitCR _ false.
		(row _ container rectanglesAt: lineY height: lineHeight)
			withIndexDo:
			[:r :i | (charIndex <= text size and: [hitCR not]) ifTrue:
				[line _ scanner composeFrom: charIndex inRectangle: r
						firstLine: firstLine leftSide: i=1 rightSide: i=row size.
				lines addLast: line.
				(text at: line last) = Character cr ifTrue: [hitCR _ true].
				lineHeight _ lineHeight max: line lineHeight.  "includes font changes"
				charIndex _ line last + 1]].
		row size >= 1 ifTrue:
		[lineY _ lineY + lineHeight.
		lineY > container bottom
			ifTrue: ["Oops -- the line is really too high to fit -- back out"
					charIndex _ saveCharIndex.
					row do: [:r | lines removeLast]]
			ifFalse: ["It's OK -- the line still fits."
					maxRightX _ maxRightX max: scanner rightX.
					1 to: row size - 1 do:  "Adjust heights across row if necess"
						[:i | (lines at: lines size - row size + i)
								lineHeight: lines last lineHeight
								baseline: lines last baseline].
					charIndex > text size ifTrue:
						["end of text"
						lines _ lines asArray.
						^ maxRightX].
					firstLine _ false]]
			ifFalse:
			[lineY _ lineY + lineHeight]].
	firstLine ifTrue:
		["No space in container or empty text"
		line _ (TextLine start: startingIndex stop: startingIndex-1
						internalSpaces: 0 paddingWidth: 0)
				rectangle: (container topLeft extent: 0@lineHeightGuess);
				lineHeight: lineHeightGuess baseline: textStyle baseline.
		lines _ Array with: line].
	"end of container"
	lines _ lines asArray.
	^ maxRightX