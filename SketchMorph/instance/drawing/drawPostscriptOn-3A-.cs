drawPostscriptOn: aCanvas

	| top f2 c2 tfx clrs |

	tfx _ self transformFrom: self world.
	tfx angle = 0.0 ifFalse: [^super drawPostscriptOn: aCanvas].	"can't do rotated yet"
	clrs _ self rotatedForm colorsUsed.
	(clrs includes: Color transparent) 
		ifFalse: [^super drawPostscriptOn: aCanvas].		"no need for this, then"

"Smalltalk at: #Q put: OrderedCollection new"
"Q add: {self. tfx. clrs}."
"(self hasProperty: #BOB) ifTrue: [self halt]."

	top _ aCanvas topLevelMorph.
	f2 _ Form extent: self extent depth: self rotatedForm depth.
	c2 _ f2 getCanvas.
	c2 fillColor: Color white.
	c2 translateBy: bounds origin negated clippingTo: f2 boundingBox during: [ :c |
		top fullDrawOn: c
	].
	aCanvas paintImage: f2 at: bounds origin

