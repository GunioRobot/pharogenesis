pageRectangles

	| pageBounds allPageRects maxExtent |

	geeMail ifNotNil: [
		allPageRects _ geeMail pageRectanglesForPrinting.
		allPageRects ifNotNil: [
			maxExtent _ allPageRects inject: 0@0 into: [ :max :each |
				max max: each extent
			].
			computedBounds _ 0@0 extent: maxExtent.
			^allPageRects
		].
	].
	pageBounds _ self bounds.
	allPageRects _ OrderedCollection new.
	[pageBounds top <= pasteUp bottom] whileTrue: [
		allPageRects add: pageBounds.
		pageBounds _ pageBounds translateBy: 0 @ pageBounds height.
	].
	^allPageRects
