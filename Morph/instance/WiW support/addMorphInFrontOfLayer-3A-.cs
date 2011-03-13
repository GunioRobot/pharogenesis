addMorphInFrontOfLayer: aMorph

	| targetLayer |
	targetLayer _ aMorph morphicLayerNumber.
	submorphs do: [ :each |
		each == aMorph ifTrue: [^self].
		"the <= is the difference - it insures we go to the front of our layer"
		targetLayer <= each morphicLayerNumber ifTrue: [
			^self addMorph: aMorph inFrontOf: each
		].
	].
	self addMorphBack: aMorph
