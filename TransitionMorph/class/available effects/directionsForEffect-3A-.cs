directionsForEffect: eff
	 "All these arrays are ordered so inverse is atWrap: size//2."
	(#(slideOver slideBoth slideAway slideBorder) includes: eff)
		ifTrue: [^ #(right downRight down downLeft left upLeft up upRight)].
	(#(pageForward pageBack) includes: eff)
		ifTrue: [^ #(right down left up)].
	(#(frenchDoor) includes: eff)
		ifTrue: [^ #(in inH out outH)].
	(#(zoomFrame zoom) includes: eff)
		ifTrue: [^ #(in out)].
	^ Array new