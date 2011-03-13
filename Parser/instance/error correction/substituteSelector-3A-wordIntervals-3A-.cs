substituteSelector: selectorParts wordIntervals: spots
	"Substitute the correctSelector into the (presuamed interactive) receiver."
	| offset |
	offset _ 0.
	selectorParts with: spots do:
		[ :word :interval |
		offset _ self substituteWord: word wordInterval: interval offset: offset ]
