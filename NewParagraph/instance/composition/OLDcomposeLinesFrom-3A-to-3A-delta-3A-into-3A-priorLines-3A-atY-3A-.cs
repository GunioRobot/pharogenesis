OLDcomposeLinesFrom: start to: stop delta: delta into: lineColl priorLines: priorLines atY: startingY 
	"While the section from start to stop has changed, composition may ripple all the way to the end of the text.  However in a rectangular container, if we ever find a line beginning with the same character as before (ie corresponding to delta in the old lines), then we can just copy the old lines from there to the end of the container, with adjusted indices and y-values"

	| charIndex lineY lineHeight scanner line row firstLine lineHeightGuess saveCharIndex hitCR maybeSlide sliding bottom priorIndex priorLine |
	charIndex := start.
	lines := lineColl.
	lineY := startingY.
	lineHeightGuess := textStyle lineGrid.
	maxRightX := container left.
	maybeSlide := stop < text size and: [container isMemberOf: Rectangle].
	sliding := false.
	priorIndex := 1.
	bottom := container bottom.
	scanner := CompositionScanner new text: text textStyle: textStyle.
	firstLine := true.
	[charIndex <= text size and: [lineY + lineHeightGuess <= bottom]] 
		whileTrue: 
			[sliding 
				ifTrue: 
					["Having detected the end of rippling recoposition, we are only sliding old lines"

					priorIndex < priorLines size 
						ifTrue: 
							["Adjust and re-use previously composed line"

							priorIndex := priorIndex + 1.
							priorLine := (priorLines at: priorIndex) slideIndexBy: delta
										andMoveTopTo: lineY.
							lineColl addLast: priorLine.
							lineY := priorLine bottom.
							charIndex := priorLine last + 1]
						ifFalse: 
							["There are no more priorLines to slide."

							sliding := maybeSlide := false]]
				ifFalse: 
					[lineHeight := lineHeightGuess.
					saveCharIndex := charIndex.
					hitCR := false.
					row := container rectanglesAt: lineY height: lineHeight.
					1 to: row size
						do: 
							[:i | 
							(charIndex <= text size and: [hitCR not]) 
								ifTrue: 
									[line := scanner 
												composeFrom: charIndex
												inRectangle: (row at: i)
												firstLine: firstLine
												leftSide: i = 1
												rightSide: i = row size.
									lines addLast: line.
									(text at: line last) = Character cr ifTrue: [hitCR := true].
									lineHeight := lineHeight max: line lineHeight.	"includes font changes"
									charIndex := line last + 1]].

					lineY := lineY + lineHeight.
					row notEmpty 
						ifTrue: 
							[lineY > bottom 
								ifTrue: 
									["Oops -- the line is really too high to fit -- back out"

									charIndex := saveCharIndex.
									row do: [:r | lines removeLast]]
								ifFalse: 
									["It's OK -- the line still fits."

									maxRightX := maxRightX max: scanner rightX.
									1 to: row size - 1
										do: 
											[:i | 
											"Adjust heights across row if necess"

											(lines at: lines size - row size + i) lineHeight: lines last lineHeight
												baseline: lines last baseline].
									charIndex > text size 
										ifTrue: 
											["end of text"

											hitCR 
												ifTrue: 
													["If text ends with CR, add a null line at the end"

													lineY + lineHeightGuess <= container bottom 
														ifTrue: 
															[row := container rectanglesAt: lineY height: lineHeightGuess.
															row notEmpty 
																ifTrue: 
																	[line := (TextLine 
																				start: charIndex
																				stop: charIndex - 1
																				internalSpaces: 0
																				paddingWidth: 0)
																				rectangle: row first;
																				lineHeight: lineHeightGuess baseline: textStyle baseline.
																	lines addLast: line]]].
											lines := lines asArray.
											^maxRightX].
									firstLine := false]].
						
					(maybeSlide and: [charIndex > stop]) 
						ifTrue: 
							["Check whether we are now in sync with previously composed lines"

							
							[priorIndex < priorLines size 
								and: [(priorLines at: priorIndex) first < (charIndex - delta)]] 
									whileTrue: [priorIndex := priorIndex + 1].
							(priorLines at: priorIndex) first = (charIndex - delta) 
								ifTrue: 
									["Yes -- next line will have same start as prior line."

									priorIndex := priorIndex - 1.
									maybeSlide := false.
									sliding := true]
								ifFalse: 
									[priorIndex = priorLines size 
										ifTrue: 
											["Weve reached the end of priorLines,
								so no use to keep looking for lines to slide."

											maybeSlide := false]]]]].
	firstLine 
		ifTrue: 
			["No space in container or empty text"

			line := (TextLine 
						start: start
						stop: start - 1
						internalSpaces: 0
						paddingWidth: 0)
						rectangle: (container topLeft extent: 0 @ lineHeightGuess);
						lineHeight: lineHeightGuess baseline: textStyle baseline.
			lines := Array with: line]
		ifFalse: [self fixLastWithHeight: lineHeightGuess].
	"end of container"
	lines := lines asArray.
	^maxRightX