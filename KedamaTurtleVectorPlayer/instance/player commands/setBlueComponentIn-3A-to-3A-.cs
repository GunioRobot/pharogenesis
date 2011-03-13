setBlueComponentIn: aPatch to: value

	| pix xArray yArray patch component |
	xArray := arrays at: 2.
	yArray := arrays at: 3.
	patch := aPatch costume renderedMorph.
	value isCollection ifFalse: [
		component := value asInteger bitAnd: 16rFF.
	].
	(1 to: self size) do: [:i |
		value isCollection ifTrue: [
			component := (value at: i) asInteger bitAnd: 16rFF.
		].
		pix := patch pixelAtX: (xArray at: i) y: (yArray at: i).
		pix := (pix bitAnd: 16rFFFF00) bitOr: component.
		patch pixelAtX: (xArray at: i) y: (yArray at: i) put: pix.
	].
