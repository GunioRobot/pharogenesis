writeFrame: aForm on: aBinaryStream quality: quality displayFlag: displayFlag
	"Compress and the given Form on the given stream and answer its offset. If displayFlag is true, show the result of JPEG compression on the display."

	| offset compressed outForm |
	offset _ aBinaryStream position.
	compressed _ JPEGReadWriter2 new compress: aForm quality: quality.
	displayFlag ifTrue: [  "show decompressed frame"
		outForm _ (JPEGReadWriter2 on: (ReadStream on: compressed)) nextImage.
		outForm display].
	aBinaryStream nextPutAll: compressed.
	^ offset
