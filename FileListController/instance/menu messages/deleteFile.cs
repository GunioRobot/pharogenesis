deleteFile
	"FileIn all of the selected file."
	model isLocked ifTrue: [^view flash].
	self controlTerminate.
	model deleteFile.
	self controlInitialize