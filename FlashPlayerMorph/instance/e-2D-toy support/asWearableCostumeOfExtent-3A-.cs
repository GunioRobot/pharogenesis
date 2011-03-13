asWearableCostumeOfExtent: extent
	"Return a wearable costume for some player"
	| image oldExtent |
	oldExtent := self extent.
	self extent: extent.
	image := self imageForm.
	self extent: oldExtent.
	image mapColor: self color to: Color transparent.
	^(World drawingClass withForm: image) copyCostumeStateFrom: self