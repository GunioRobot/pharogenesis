whereIs: aPoint 
	| location side |
	location _ #inside.
	self edges do: 
		[:edge | 
		side _ edge sideOf: aPoint.
		side = #right ifTrue: [^ #outside].
		side = #center ifTrue: [location _ #edge]].
	^ location