touchesColor: soughtColor
	"Return true if any of my pixels overlap pixels of soughtColor."
	| map patchBelowMe shadowForm tfm morphAsFlexed |
	"Make a sahdow mask with black in my shape, white elsewhere"
	tfm _ self transformFrom: self world.
	morphAsFlexed _ tfm isIdentity
		ifTrue: [self]
		ifFalse: [TransformationMorph new
					flexing: self clone
					byTransformation: tfm].
	shadowForm _ morphAsFlexed shadowForm offset: 0@0.

	"get an image of the world below me"
	patchBelowMe _ (self world patchAt: morphAsFlexed fullBounds
								without: self andNothingAbove: false) offset: 0@0.
"
shadowForm displayAt: 0@0.
patchBelowMe displayAt: 100@0.
"
	"intersect world pixels of the color we're looking for with our shape."
	map _ Bitmap new: (1 bitShift: (patchBelowMe depth min: 15)).
	map at: (soughtColor indexInMap: map) put: 1.
	shadowForm copyBits: patchBelowMe boundingBox
		from: patchBelowMe
		at: 0@0
		clippingBox: patchBelowMe boundingBox
		rule: Form and
		fillColor: nil
		map: map.
"
shadowForm displayAt: 200@0.
"
	^ (shadowForm tallyPixelValues at: 2) > 0
