showPalette: aPalette
	| hadPalette |
	hadPalette _ currentPalette notNil.
	currentPalette ifNotNil:
		[currentPalette == aPalette ifTrue: [^ self].
		currentPalette == paintPalette ifTrue: [paintPalette keep: nil with: #silent].
		currentPalette ifNotNil: [currentPalette delete]].
	currentPalette _ aPalette.
	aPalette ifNil: [^ self]. 
	aPalette fullBounds.
	((currentPalette == paintPalette) or: [currentPalette == viewPalette])
		ifFalse: [aPalette position: (self world bounds right @ self bounds bottom) +
										paletteOffset - (aPalette width @ 0)]
		ifTrue: [aPalette align: aPalette topRight with: self world right @ self bottom].

	owner addMorph: aPalette.
	aPalette changed.
	aPalette allMorphsDo: [:m | m layoutChanged].
	self world startSteppingSubmorphsOf: aPalette.
	hadPalette ifTrue:
		[Display slideImage: aPalette imageForm
			at: aPalette screenRectangle origin
			delta: 9@-12].

