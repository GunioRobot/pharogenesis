desktopFillStyleFor: aWorld
	"Answer the desktop fill style for the given world.
	Answer nil for no change."

	|filename|
	filename := FileDirectory fileName: self class themeName extension: 'jpg'.
	^(FileDirectory default fileExists:	filename) ifTrue: [
		BitmapFillStyle
			fromForm: (ImageReadWriter formFromFileNamed: filename)]