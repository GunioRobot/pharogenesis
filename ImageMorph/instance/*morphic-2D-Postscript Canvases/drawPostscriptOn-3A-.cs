drawPostscriptOn: aCanvas

	| top f2 c2 clrs |

	clrs _ image colorsUsed.
	(clrs includes: Color transparent) 
		ifFalse: [^super drawPostscriptOn: aCanvas].		"no need for this, then"

	top _ aCanvas topLevelMorph.
	f2 _ Form extent: self extent depth: image depth.
	c2 _ f2 getCanvas.
	c2 fillColor: Color white.
	c2 translateBy: bounds origin negated clippingTo: f2 boundingBox during: [ :c |
		top fullDrawOn: c
	].
	aCanvas paintImage: f2 at: bounds origin

