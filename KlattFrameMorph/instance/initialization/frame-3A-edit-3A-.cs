frame: aKlattFrame edit: params
	frame _ aKlattFrame.
	self addSlidersForParameters: params.
	(params detect: [ :one | #(ro ra rk) includes: one] ifNone: []) notNil
		ifTrue: [glottal _ GraphMorph new extent: 210 @ 100.
				glottal setBalloonText: 'Glottal pulse'.
				self addMorphBack: glottal]