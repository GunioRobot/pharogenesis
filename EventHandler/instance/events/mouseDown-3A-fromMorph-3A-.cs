mouseDown: event fromMorph: sourceMorph 
	"Take double-clicks into account."
	((self handlesDoubleClick: event)
		and: [event redButtonPressed])
		ifTrue: 
			[event hand waitForClicksOrDrag: sourceMorph event: event.
			^ nil]
		ifFalse: [^ self click: event fromMorph: sourceMorph]