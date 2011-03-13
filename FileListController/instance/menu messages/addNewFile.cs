addNewFile
	"FileIn all of the selected file."
	model isLocked ifTrue: [^view flash].
	self controlTerminate.
	model addNewFile.
	self controlInitialize