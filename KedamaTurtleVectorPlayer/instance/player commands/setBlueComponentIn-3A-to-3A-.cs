setBlueComponentIn: aPatch to: value

	| pix xArray yArray patch component |
	xArray _ arrays at: 2.
	yArray _ arrays at: 3.
	patch _ aPatch costume renderedMorph.
	value isCollection ifFalse: [
		component _ value asInteger bitAnd: 16rFF.
	].
	(1 to: self size) do: [:i |
		value isCollection ifTrue: [
			component _ (value at: i) asInteger bitAnd: 16rFF.
		].
		pix _ patch pixelAtX: (xArray at: i) y: (yArray at: i).
		pix _ (pix bitAnd: 16rFFFF00) bitOr: component.
		patch pixelAtX: (xArray at: i) y: (yArray at: i) put: pix.
	].
