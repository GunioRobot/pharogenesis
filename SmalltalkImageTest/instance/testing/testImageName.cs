testImageName
	"Non regression test for http://bugs.squeak.org/view.php?id=7351"
	| shortImgName fullImgName fullChgName |
	shortImgName := 'Squeak3.10.2-7179-basic'.
	fullImgName := SmalltalkImage current fullNameForImageNamed: shortImgName.
	fullChgName := SmalltalkImage current fullNameForChangesNamed: shortImgName.
	FileDirectory splitName: fullImgName to: [:path :name |
		self assert: path = SmalltalkImage current imagePath.
		self assert: name = 'Squeak3.10.2-7179-basic.image'.].
	FileDirectory splitName: fullChgName to: [:path :name |
		self assert: path = SmalltalkImage current imagePath.
		self assert: name = 'Squeak3.10.2-7179-basic.changes'.].