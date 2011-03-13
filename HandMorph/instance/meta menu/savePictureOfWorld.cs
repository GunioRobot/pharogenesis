savePictureOfWorld
	"Write a GIF file on the disk that is a picture of this world.  For
printing and making pictures of your EToy.  tk 9/14/97"

	"Determine file name"
	| candidates num picture ss |
	candidates _ FileDirectory default fileNamesMatching: 'EToy','*',
'.gif'.
	num _ 0.
	[num _ num + 1.
		ss _ num printString.
		ss size = 1 ifTrue: [ss _ '0',ss].	"Leading zero, so
will be in alphabetical order"
		(candidates includes: 'EToy', ss, '.gif')] whileTrue.
	picture _ self world imageFormForRectangle: self world bounds.
	GIFReadWriter putForm: picture
		onFileNamed: 'EToy', ss, '.gif'.
