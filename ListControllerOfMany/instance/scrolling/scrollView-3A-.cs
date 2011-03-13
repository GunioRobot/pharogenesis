scrollView: anInteger 
	"Need to minimize the selections which get recomputed"
	| oldLimit |
	oldLimit _ anInteger > 0
		ifTrue: [view firstShown]
		ifFalse: [view lastShown].
	(view scrollBy: anInteger)
		ifTrue: [anInteger > 0  "Highlight selections brought into view"
					ifTrue: [view highlightFrom: view firstShown
								to: (oldLimit-1 min: view lastShown)]
					ifFalse: [view highlightFrom: (oldLimit+1 max: view firstShown)
								to: view lastShown].
				^ true]
		ifFalse: [^ false]