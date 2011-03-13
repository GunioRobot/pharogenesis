displayLines: linesInterval affectedRectangle: affectedRectangle
	"This is the first level workhorse in the display portion of the TextForm routines.
	It checks to see which lines in the interval are actually visible, has the
	CharacterScanner display only those, clears out the areas in which display will
	occur, and clears any space remaining in the visibleRectangle following the space
	occupied by lastLine."

	| lineGrid topY firstLineIndex lastLineIndex lastLineIndexBottom |
	lineGrid _ textStyle lineGrid.
	"Save some time by only displaying visible lines"
	firstLineIndex _ self lineIndexOfTop: affectedRectangle top.
	firstLineIndex < linesInterval first ifTrue: [firstLineIndex _ linesInterval first].
	lastLineIndex _ self lineIndexOfTop: affectedRectangle bottom - 1.
	lastLineIndex > linesInterval last 
		ifTrue:
			[linesInterval last > lastLine
		 		ifTrue: [lastLineIndex _ lastLine]
		  		ifFalse: [lastLineIndex _ linesInterval last]].
	((Rectangle 
		origin: affectedRectangle left @ (topY _ self topAtLineIndex: firstLineIndex) 
		corner: affectedRectangle right @ 
					(lastLineIndexBottom _ (self topAtLineIndex: lastLineIndex)
					  + lineGrid))
	  intersects: affectedRectangle)
		ifTrue: [ " . . . (skip to clear-below if no lines displayed)"
	"Clear space for the lines in linesInterval."
	destinationForm
	  fill: (affectedRectangle left @ (topY max: affectedRectangle top)
			corner: affectedRectangle right @ (lastLineIndexBottom min: affectedRectangle bottom))
	  rule: rule fillColor: self backgroundColor.
	DisplayScanner new
	  displayLines: (firstLineIndex to: lastLineIndex)
	  in: self clippedBy: affectedRectangle].
	lastLineIndex = lastLine ifTrue: 
		 [destinationForm  "Clear out white space below last line"
		 	fill: (affectedRectangle left @ (lastLineIndexBottom max: affectedRectangle top)
				corner: affectedRectangle bottomRight)
		 	rule: rule fillColor: self backgroundColor]