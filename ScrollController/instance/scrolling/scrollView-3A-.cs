scrollView: anInteger 
	"Tell the reciever's view to scroll by anInteger amount.
	Return true only if scrolling actually resulted."
	(view scrollBy: 0 @ 
				((anInteger min: view window top - view boundingBox top)
						max: view window top - view boundingBox bottom))
		ifTrue: [view clearInside; display.  ^ true]
		ifFalse: [^ false]