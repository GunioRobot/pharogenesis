composeEachRectangleIn: rectangles

	| myLine lastChar |

	1 to: rectangles size do: [:i | 
		currCharIndex <= theText size ifFalse: [^false].
		myLine _ scanner 
			composeFrom: currCharIndex 
			inRectangle: (rectangles at: i)				
			firstLine: isFirstLine 
			leftSide: i=1 
			rightSide: i=rectangles size.
		lines addLast: myLine.
		presentationLines addLast: scanner getPresentationLine.
		presentation ifNil: [presentation _ scanner getPresentation]
			ifNotNil: [presentation _ presentation, scanner getPresentation].
		actualHeight _ actualHeight max: myLine lineHeight.  "includes font changes"
		currCharIndex _ myLine last + 1.
		lastChar _ theText at: myLine last.
		lastChar = Character cr ifTrue: [^#cr].
		wantsColumnBreaks ifTrue: [
			lastChar = TextComposer characterForColumnBreak ifTrue: [^#columnBreak].
		].
	].
	^false