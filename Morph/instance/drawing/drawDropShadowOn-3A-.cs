drawDropShadowOn: aCanvas

	aCanvas 
		translateBy: self shadowOffset 
		during: [ :shadowCanvas |
			shadowCanvas shadowColor: self shadowColor.
			shadowCanvas roundCornersOf: self during: [ 
				(shadowCanvas isVisible: self bounds) ifTrue:[shadowCanvas drawMorph: self ]]
		].
