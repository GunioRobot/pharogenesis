setSelectedDirectoryTo: aFileDirectoryWrapper

	currentDirectorySelected _ aFileDirectoryWrapper.
	self directory: aFileDirectoryWrapper withoutListWrapper.
	brevityState := #FileList.
	"self addPath: path."
	self changed: #fileList.
	self changed: #contents.
	self changed: #getSelectedDirectory.