workingCopy: wc
	workingCopy := wc.
	self changed: #workingCopyList; changed: #workingCopySelection; changed: #repositoryList.
	self changedButtons.
