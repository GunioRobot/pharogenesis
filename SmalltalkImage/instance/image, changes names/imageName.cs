imageName
	"Answer the full path name for the current image."
	"SmalltalkImage current imageName"

	| str |
	str _ self primImageName.
	^ (FilePath pathName: str isEncoded: true) asSqueakPathName.
