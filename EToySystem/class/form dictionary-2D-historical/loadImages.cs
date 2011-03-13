loadImages
	"Bring in images from BMP files to forms"
	| coverForm |
	coverForm _ Form fromBMPFileNamed: 'cover text.BMP' depth: 8.
	self formDictionary at: 'CoverMain' put: coverForm.

	coverForm removeZeroPixelsFromForm.
	"Turn Green into transparent"
	coverForm _ coverForm as8BitColorForm.
	coverForm colors at: (Color green pixelValueForDepth: 8)+1 put: Color transparent.
	coverForm colors: coverForm colors.	"redo its cache"
	self loadImages2.
	"self formDictionary removeKey: 'CoverMain'"	"later to save space, clobber the CoverMain form"

	self formDictionary at: 'CoverSpiral' put:  (GIFReadWriter formFromFileNamed: 'spiral.GIF').
	self formDictionary at: 'CoverTexture' put: (Form fromBMPFileNamed: 'texture.BMP' depth: 8).
	(self formDictionary at: 'CoverTexture') removeZeroPixelsFromForm.
