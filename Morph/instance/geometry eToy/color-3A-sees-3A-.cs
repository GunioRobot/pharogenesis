color: sensitiveColor sees: soughtColor
	"Return true if any of my pixels of sensitiveColor intersect with pixels of soughtColor."
	| myImage sensitivePixelMask map patchBelowMe tfm morphAsFlexed i1 |
	"Make a mask with black where sensitiveColor is, white elsewhere"
	tfm _ self transformFrom: self world.
	morphAsFlexed _ tfm isIdentity
		ifTrue: [self]
		ifFalse: [TransformationMorph new
					flexing: self clone
					byTransformation: tfm].
	myImage _ morphAsFlexed imageForm offset: 0@0.
	sensitivePixelMask _ Form extent: myImage extent depth: 1.
	map _ Bitmap new: (1 bitShift: (myImage depth min: 15)).
	map at: (i1 _ sensitiveColor indexInMap: map) put: 1.
	sensitivePixelMask copyBits: sensitivePixelMask boundingBox
		from: myImage form at: 0@0 colorMap: map.

	"get an image of the world below me"
	patchBelowMe _ self world patchAt: morphAsFlexed fullBounds
								without: self andNothingAbove: false.
"
sensitivePixelMask displayAt: 0@0.
patchBelowMe displayAt: 100@0.
"
	"intersect world pixels of the color we're looking for with the sensitive pixels"
	map at: i1 put: 0.  "clear map and reuse it"
	map at: (soughtColor indexInMap: map) put: 1.
	sensitivePixelMask copyBits: patchBelowMe boundingBox
		from: patchBelowMe at: 0@0 clippingBox: patchBelowMe boundingBox
		rule: Form and fillColor: nil map: map.
"
sensitivePixelMask displayAt: 200@0.
"
	^ (sensitivePixelMask tallyPixelValues at: 2) > 0
