multiComposeLinesFrom: start to: stop delta: delta into: lineColl priorLines: priorLines
	atY: startingY
	"While the section from start to stop has changed, composition may ripple all the way to the end of the text.  However in a rectangular container, if we ever find a line beginning with the same character as before (ie corresponding to delta in the old lines), then we can just copy the old lines from there to the end of the container, with adjusted indices and y-values"

	| newResult composer presentationInfo |

	composer := MultiTextComposer new.
	presentationLines := nil.
	presentationText := nil.
	newResult := composer
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
	lines := newResult first asArray.
	maxRightX := newResult second.
	presentationInfo := composer getPresentationInfo.
	presentationLines := presentationInfo first asArray.
	presentationText := presentationInfo second.
	"maxRightX printString displayAt: 0@0."
	^maxRightX
