bordersOn: otherView along: herSide 
	| myBox herBox |
	myBox _ self displayBox.
	herBox _ otherView displayBox.
	(herSide = #right and: [myBox left = herBox right])
	| (herSide = #left and: [myBox right = herBox left])
		ifTrue:
		[^ (myBox top max: herBox top) <= (myBox bottom min: herBox bottom)].
	(herSide = #bottom and: [myBox top = herBox bottom])
	| (herSide = #top and: [myBox bottom = herBox top])
		ifTrue:
		[^ (myBox left max: herBox left) <= (myBox right min: herBox right)].
	^ false