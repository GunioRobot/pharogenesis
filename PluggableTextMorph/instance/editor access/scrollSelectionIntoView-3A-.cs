scrollSelectionIntoView: event
	"Scroll my text into view if necessary and return true, else return false"
	| selRects delta selRect rectToTest |
	selRects _ textMorph paragraph selectionRects.
	selRects isEmpty ifTrue: [^ false].
	rectToTest _ selRects first merge: selRects last.
	(event notNil and: [event anyButtonPressed]) ifTrue:  "Check for autoscroll"
		[event cursorPoint y <= self top
			ifTrue: [rectToTest _ selRects first topLeft extent: 2@2].
		event cursorPoint y >= self bottom
			ifTrue: [rectToTest _ selRects last bottomRight extent: 2@2].
		selectionInterval _ textMorph editor selectionInterval].
	selRect _ (scroller transformFrom: self) invertRect: rectToTest.
	(delta _ selRect amountToTranslateWithin: self bounds) y ~= 0 ifTrue:
		["Scroll end of selection into view if necessary"
		self scrollBy: 0@delta y.
		^ true].
	^ false