composeAllRectangles: rectangles

	| charIndexBeforeLine numberOfLinesBefore reasonForStopping |

	actualHeight _ defaultLineHeight.
	charIndexBeforeLine _ currCharIndex.
	numberOfLinesBefore _ lines size.
	reasonForStopping _ self composeEachRectangleIn: rectangles.

	currentY _ currentY + actualHeight.
	currentY > theContainer bottom ifTrue: [
		"Oops -- the line is really too high to fit -- back out"
		currCharIndex _ charIndexBeforeLine.
		lines size - numberOfLinesBefore timesRepeat: [lines removeLast].
		^self
	].
	
	"It's OK -- the line still fits."
	maxRightX _ maxRightX max: scanner rightX.
	1 to: rectangles size - 1 do: [ :i |
		"Adjust heights across rectangles if necessary"
		(lines at: lines size - rectangles size + i)
			lineHeight: lines last lineHeight
			baseline: lines last baseline
	].
	isFirstLine _ false.
	reasonForStopping == #columnBreak ifTrue: [^nil].
	currCharIndex > theText size ifTrue: [
		^nil		"we are finished composing"
	].
	