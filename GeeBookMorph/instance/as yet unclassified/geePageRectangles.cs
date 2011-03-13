geePageRectangles

	| pageBounds allPageRects |

	pageBounds _ geeMail topLeft 
			extent: geeMail width @ (geeMail height min: Display height - 50).
	allPageRects _ OrderedCollection new.
	[pageBounds top <= geeMail bottom] whileTrue: [
		allPageRects add: pageBounds.
		pageBounds _ pageBounds translateBy: 0 @ pageBounds height.
	].
	^allPageRects
