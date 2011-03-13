from: aForm box: aRect
  	"From Alan's 2/96 painting code."

	| oform |
	oform _ Form extent: aRect extent depth: aForm depth.
	oform copyBits: aRect from: aForm at: 0@0 
		clippingBox: oform boundingBox rule: Form over fillColor: nil.
	^ self transparentBorder: oform
