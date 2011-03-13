head: aHeadMorph
	head notNil ifTrue: [aHeadMorph position: head position. head delete].
	head := aHeadMorph