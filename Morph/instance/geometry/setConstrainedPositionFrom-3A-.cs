setConstrainedPositionFrom: aPoint
	"Change the position of this morph and and all of its submorphs to aPoint, but don't let me go outside my owner's bounds."

	| trialRect delta boundingMorph |
	trialRect _ aPoint extent: self bounds extent.
	boundingMorph _ self owner topRendererOrSelf.
	delta _ boundingMorph
			ifNil:    [0@0]
			ifNotNil: [trialRect amountToTranslateWithin: boundingMorph bounds].
	self position: aPoint + delta.
	self layoutChanged  "So that, eg, surrounding text will readjust"
