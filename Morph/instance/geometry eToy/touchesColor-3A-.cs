touchesColor: soughtColor 
	"Return true if any of my pixels overlap pixels of soughtColor."

	"Make a shadow mask with black in my shape, white elsewhere"

	| map patchBelowMe shadowForm tfm morphAsFlexed pasteUp |
	pasteUp := self world ifNil: [ ^false ].

	tfm := self transformFrom: pasteUp.
	morphAsFlexed := tfm isIdentity 
				ifTrue: [self]
				ifFalse: [TransformationMorph new flexing: self clone byTransformation: tfm].
	shadowForm := morphAsFlexed shadowForm offset: 0 @ 0.

	"get an image of the world below me"
	patchBelowMe := (pasteUp 
				patchAt: morphAsFlexed fullBounds
				without: self
				andNothingAbove: false) offset: 0 @ 0.
	"
shadowForm displayAt: 0@0.
patchBelowMe displayAt: 100@0.
"
	"intersect world pixels of the color we're looking for with our shape."
	"ensure a maximum 16-bit map"
	map := Bitmap new: (1 bitShift: (patchBelowMe depth - 1 min: 15)).
	map at: (soughtColor indexInMap: map) put: 1.
	shadowForm 
		copyBits: patchBelowMe boundingBox
		from: patchBelowMe
		at: 0 @ 0
		clippingBox: patchBelowMe boundingBox
		rule: Form and
		fillColor: nil
		map: map.
	"
shadowForm displayAt: 200@0.
"
	^(shadowForm tallyPixelValues second) > 0