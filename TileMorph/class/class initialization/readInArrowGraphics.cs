readInArrowGraphics
	"TileMorph readInArrowGraphics"

	| obj |
	obj _ (FileStream readOnlyFileNamed: 'tile inc arrow.morph') fileInObjectAndCode.
	UpPicture _ obj form.

	obj _ (FileStream readOnlyFileNamed: 'tile dec arrow.morph') fileInObjectAndCode.
	DownPicture _ obj form.

	obj _ (FileStream readOnlyFileNamed: 'tile suffix arrow.morph')fileInObjectAndCode.
	SuffixPicture _ obj form.