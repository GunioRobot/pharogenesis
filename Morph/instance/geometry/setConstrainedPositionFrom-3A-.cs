setConstrainedPositionFrom: aPoint
	"Change the position of this morph and and all of its submorphs to aPoint, but don't let me go outside my owner's bounds."

	| trialRect delta |
	trialRect _ aPoint extent: self bounds extent.
	delta _ trialRect amountToTranslateWithin: owner bounds.
	self position: aPoint + delta
