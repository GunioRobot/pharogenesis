selectUnchangedMethods
	"Select all methods in the receiver whose source is identical to the corresponding source currently in the image.  9/18/96 sw"

	self controlTerminate.
	model selectUnchangedMethods.
	self controlInitialize