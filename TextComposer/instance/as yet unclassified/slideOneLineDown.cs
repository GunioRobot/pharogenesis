slideOneLineDown

	| priorLine |

	"Having detected the end of rippling recoposition, we are only sliding old lines"
	prevIndex < prevLines size ifFalse: [
		"There are no more prevLines to slide."
		^nowSliding _ possibleSlide _ false
	].

	"Adjust and re-use previously composed line"
	prevIndex _ prevIndex + 1.
	priorLine _ (prevLines at: prevIndex)
				slideIndexBy: deltaCharIndex andMoveTopTo: currentY.
	lines addLast: priorLine.
	currentY _ priorLine bottom.
	currCharIndex _ priorLine last + 1.
	wantsColumnBreaks ifTrue: [
		priorLine first to: priorLine last do: [ :i |
			(theText at: i) = TextComposer characterForColumnBreak ifTrue: [
				nowSliding _ possibleSlide _ false.
				^nil
			].
		].
	].
