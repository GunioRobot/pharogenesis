openTutorial
	"B3DTutorialPresenter openTutorial"
	| data tutorial |
	data := (Base64MimeConverter mimeDecode: self tutorial as: String) unzipped.
	(RWBinaryOrTextStream with: data) reset; fileIn.
	tutorial := SmartRefStream scannedObject.
	(Workspace new contents: tutorial) openLabel: 'Balloon3D tutorial'