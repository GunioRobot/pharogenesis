drawOnTextureOf: anActor from: texStart to: texEnd
	"texStart and texEnd are Coordinates on a Texture"
	| texture range start end |
	texture _ anActor getTexturePointer.
	range _ texture extent.
	start _ range * texStart.
	end _ range * texEnd.
	texture drawLine: (Form dotOfSize: 3) from: start to: end clippingBox: (1@1 extent: range) rule: Form over fillColor: nil 

