scrollView: anInteger 
	"Scroll the view and highlight the selection if it just came into view"
	| wasClipped |
	wasClipped _ view isSelectionBoxClipped.
	(view scrollBy: anInteger)
		ifTrue: [view isSelectionBoxClipped ifFalse:
					[wasClipped ifTrue:  "Selection came into view"
						[view displaySelectionBox]].
				^ true]
		ifFalse: [^ false]