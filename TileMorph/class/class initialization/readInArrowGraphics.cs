readInArrowGraphics
	"TileMorph readInArrowGraphics"

	| obj |
	obj _ (FileStream oldFileNamed: 'tile inc arrow.morph') fileInObjectAndCode.
	UpPicture _ obj form.

	obj _ (FileStream oldFileNamed: 'tile dec arrow.morph') fileInObjectAndCode.
	DownPicture _ obj form.

	obj _ (FileStream oldFileNamed: 'tile suffix arrow.morph')fileInObjectAndCode.
	SuffixPicture _ obj form.