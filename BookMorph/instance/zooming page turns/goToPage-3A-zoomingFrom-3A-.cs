goToPage: pageNumber zoomingFrom: srcButtonMorph

	| bigBalloonMorph i newPage cachedMorph zoomer |
	pages isEmpty ifTrue: [^ self].

	(self isInWorld and:
	 [self world modelOrNil respondsTo: #bigBalloonMorph])
		ifTrue: [bigBalloonMorph _ self world model bigBalloonMorph fullCopy]
		ifFalse: [^ self goToPage: pageNumber].

	bigBalloonMorph position: self world model scaffoldingBook root fullBounds origin.
	bigBalloonMorph removeAllMorphs.
	i _ pageNumber asInteger.
	i > pages size ifTrue: [i _ 1].  "wrap"
	i < 1  ifTrue: [i _ pages size].  "wrap"
	newPage _ pages at: i.
	cachedMorph _ CachingMorph new.
	cachedMorph addMorph: bigBalloonMorph.
	bigBalloonMorph addMorph: newPage fullCopy.
	zoomer _ ZoomMorph new.
	self world addMorphFront: zoomer.
	zoomer zoomFromMorph: srcButtonMorph
							toMorph: cachedMorph
							andThen: [self goToPage: i].
	self world ifNotNil: [self world startSteppingSubmorphsOf: zoomer].
