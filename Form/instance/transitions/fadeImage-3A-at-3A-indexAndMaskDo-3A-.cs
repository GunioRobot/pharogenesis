fadeImage: otherImage at: topLeft
	indexAndMaskDo: indexAndMaskBlock
	"This fade uses halftones as a blending hack.
	Zeros in the halftone produce the original image (self), and 
	ones in the halftone produce the 'otherImage'.
	IndexAndMaskBlock gets evaluated prior to each cycle,
	and the resulting boolean determines whether to continue cycling."
	| index imageRect maskForm resultForm |
	imageRect _ otherImage boundingBox.
	resultForm _ self copy: (topLeft extent: imageRect extent).
	maskForm _ Form extent: 32@32.
	index _ 0.
	[indexAndMaskBlock value: (index _ index+1) value: maskForm]
	whileTrue:
		[maskForm reverse.
		resultForm copyBits: imageRect from: resultForm at: 0@0
			clippingBox: imageRect rule: Form over fillColor: maskForm.
		maskForm reverse.
		resultForm copyBits: imageRect from: otherImage at: 0@0
			clippingBox: imageRect rule: Form under fillColor: maskForm.
		self copyBits: imageRect from: resultForm at: topLeft
				clippingBox: self boundingBox rule: Form over fillColor: nil.
		Display forceDisplayUpdate]