addMorphInFrontOfLayer: aMorph

	| targetLayer layerHere |

	targetLayer := aMorph morphicLayerNumberWithin: self.
	submorphs do: [ :each |
		each == aMorph ifTrue: [^self].
		layerHere := each morphicLayerNumberWithin: self.
		"the <= is the difference - it insures we go to the front of our layer"
		targetLayer <= layerHere ifTrue: [
			^self addMorph: aMorph inFrontOf: each
		].
	].
	self addMorphBack: aMorph.
