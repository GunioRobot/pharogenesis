scrollSelectionIntoView: event 
	"Scroll my text into view if necessary and return true, else return false"
	| selRects delta selRect rectToTest transform cpHere |
	selectionInterval _ textMorph editor selectionInterval.
	selRects _ textMorph paragraph selectionRects.
	selRects isEmpty ifTrue: [^ false].
	rectToTest _ selRects first merge: selRects last.
	transform _ scroller transformFrom: self.
	(event notNil and: [event anyButtonPressed]) ifTrue:  "Check for autoscroll"
		[cpHere _ transform localPointToGlobal: event cursorPoint.
		cpHere y <= self top
			ifTrue: [rectToTest _ selRects first topLeft extent: 2@2]
			ifFalse: [cpHere y >= self bottom
					ifTrue: [rectToTest _ selRects last bottomRight extent: 2@2]
					ifFalse: [^ false]]].
	selRect _ transform localBoundsToGlobal: rectToTest.
	selRect height > bounds height
		ifTrue: [^ false].  "Would not fit, even if we tried to scroll"
	(delta _ selRect amountToTranslateWithin: self innerBounds) y ~= 0 ifTrue:
		["Scroll end of selection into view if necessary"
		self scrollBy: 0@delta y.
		^ true].
	^ false