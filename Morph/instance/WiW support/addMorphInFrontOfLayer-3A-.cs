addMorphInFrontOfLayer: aMorph

	| targetLayer layerHere |

	targetLayer _ aMorph morphicLayerNumberWithin: self.
	submorphs do: [ :each |
		each == aMorph ifTrue: [^self].
		layerHere _ each morphicLayerNumberWithin: self.
		"the <= is the difference - it insures we go to the front of our layer"
		targetLayer <= layerHere ifTrue: [
			^self addMorph: aMorph inFrontOf: each
		].
	].
	self addMorphBack: aMorph.
