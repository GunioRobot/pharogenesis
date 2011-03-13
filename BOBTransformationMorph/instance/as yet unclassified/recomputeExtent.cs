recomputeExtent

	| scalePt newScale theGreenThingie greenIBE myNewExtent |

	submorphs isEmpty ifTrue: [^self extent].
	worldBoundsToShow ifNil: [worldBoundsToShow _ self firstSubmorph bounds].
	worldBoundsToShow area = 0 ifTrue: [^self extent].
	scalePt _ owner innerBounds extent / worldBoundsToShow extent.
	newScale _ scalePt x min: scalePt y.
	theGreenThingie _ owner.
	greenIBE _ theGreenThingie innerBounds extent.
	myNewExtent _ (greenIBE min: worldBoundsToShow extent * newScale) truncated.
	self
		scale: newScale;
		offset: worldBoundsToShow origin * newScale.
	smoothing _ (newScale < 1.0) ifTrue: [2] ifFalse: [1].
	^myNewExtent