handleEvent: evt from: aHand
	"Process the given mouse event to detect a click, double-click, or drag.
	Return true if the event should be processed by the sender, false if it shouldn't.
	NOTE: This method heavily relies on getting *all* mouse button events."
	| localEvt timedOut isDrag |
	timedOut _ (evt timeStamp - firstClickTime) > dblClickTime.
	localEvt _ evt transformedBy: (clickClient transformedFrom: aHand owner).
	isDrag _ (localEvt cursorPoint - firstClickDown cursorPoint) r > dragThreshold.
	clickState == #firstClickDown ifTrue: [
		"Careful here - if we had a slow cycle we may have a timedOut mouseUp event"
		(timedOut and:[localEvt isMouseUp not]) ifTrue:[
			"timeout before #mouseUp -> keep waiting for drag if requested"
			clickState _ #firstClickTimedOut.
			dragSelector ifNil:[
				aHand resetClickState.
				clickSelector ifNotNil:[clickClient perform: clickSelector with: firstClickDown]].
			^true].
		localEvt isMouseUp ifTrue:[
			"If timedOut or the client's not interested in dbl clicks get outta here"
			(timedOut or:[dblClickSelector isNil]) ifTrue:[
				aHand resetClickState.
				clickSelector ifNotNil:[clickClient perform: clickSelector with: firstClickDown].
				^true].
			"Otherwise transfer to #firstClickUp"
			firstClickUp _ evt copy.
			clickState _ #firstClickUp.
			^false].
		isDrag ifTrue:["drag start"
			aHand resetClickState.
			dragSelector == nil "If no drag selector send #click instead"
				ifTrue:[clickSelector ifNotNil:[clickClient perform: clickSelector with: firstClickDown]]
				ifFalse:[clickClient perform: dragSelector with: localEvt].
			^true].
		^false].

	clickState == #firstClickTimedOut ifTrue:[
		localEvt isMouseUp ifTrue:["neither drag nor double click"
			aHand resetClickState.
			clickSelector ifNotNil:[clickClient perform: clickSelector with: firstClickDown].
			^true].
		isDrag ifTrue:["drag start"
			aHand resetClickState.
			dragSelector ifNotNil:[clickClient perform: dragSelector with: localEvt].
			^true].
		^false].

	clickState = #firstClickUp ifTrue:[
		(timedOut) ifTrue:[
			"timed out after mouseUp - send #click: and mouseUp"
			aHand resetClickState.
			clickSelector ifNotNil:[clickClient perform: clickSelector with: firstClickDown].
			"Note: Using aHand handleEvent here (rather than clickClient handleMouseUp:) to be consistent with a timeout before firstClickUp in which case aHand would process the up event."
			aHand handleEvent: firstClickUp.
			^true].
		localEvt isMouseDown ifTrue:["double click"
			aHand resetClickState.
			dblClickSelector ifNotNil:[clickClient perform: dblClickSelector with: firstClickDown].
			^false]].
	^true