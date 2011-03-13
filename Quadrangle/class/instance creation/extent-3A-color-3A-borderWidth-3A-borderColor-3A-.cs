extent: extent color: aMask2 borderWidth: anInteger borderColor: aMask1
	"Answer an instance of me with rectangle, border width and color, and 
	inside color determined by the arguments."

	^super new
		region: (0@0 corner: extent)
		borderWidth: anInteger
		borderColor: aMask1
		insideColor: aMask2