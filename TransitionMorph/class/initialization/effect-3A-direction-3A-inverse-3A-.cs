effect: effectSymbol direction: dirSymbol inverse: inverse
	| invEffect invDir i dirSet |
	inverse ifFalse: [^ self effect: effectSymbol direction: dirSymbol].

	invEffect _ effectSymbol.
	effectSymbol = #pageForward ifTrue: [invEffect _ #pageBack].
	effectSymbol = #pageBack ifTrue: [invEffect _ #pageForward].
	effectSymbol = #slideOver ifTrue: [invEffect _ #slideAway].
	effectSymbol = #slideAway ifTrue: [invEffect _ #slideOver].

	invDir _ dirSymbol.
	dirSet _ self directionsForEffect: effectSymbol.
	(i _ dirSet indexOf: dirSymbol) > 0
		ifTrue: [invDir _ dirSet atWrap: i + (dirSet size // 2)].

	^ self effect: invEffect direction: invDir