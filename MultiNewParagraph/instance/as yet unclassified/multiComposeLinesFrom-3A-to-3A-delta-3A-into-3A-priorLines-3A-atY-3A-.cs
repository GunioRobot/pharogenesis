multiComposeLinesFrom: start to: stop delta: delta into: lineColl priorLines: priorLines
	atY: startingY
	"While the section from start to stop has changed, composition may ripple all the way to the end of the text.  However in a rectangular container, if we ever find a line beginning with the same character as before (ie corresponding to delta in the old lines), then we can just copy the old lines from there to the end of the container, with adjusted indices and y-values"

	| newResult composer presentationInfo |

	composer _ MultiTextComposer new.
	presentationLines _ nil.
	presentationText _ nil.
	newResult _ composer
		multiComposeLinesFrom: start 
		to: stop 
		delta: delta 
		into: lineColl 
		priorLines: priorLines
		atY: startingY
		textStyle: textStyle 
		text: text 
		container: container
		wantsColumnBreaks: wantsColumnBreaks == true.
	lines _ newResult first asArray.
	maxRightX _ newResult second.
	presentationInfo _ composer getPresentationInfo.
	presentationLines _ presentationInfo first asArray.
	presentationText _ presentationInfo second.
	"maxRightX printString displayAt: 0@0."
	^maxRightX
