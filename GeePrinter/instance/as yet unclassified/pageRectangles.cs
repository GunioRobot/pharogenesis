pageRectangles

	| pageBounds allPageRects |

	pageBounds _ self bounds.
	allPageRects _ OrderedCollection new.
	[pageBounds top <= pasteUp bottom] whileTrue: [
		allPageRects add: pageBounds.
		pageBounds _ pageBounds translateBy: 0 @ pageBounds height.
	].
	^allPageRects
