doOK

	self validateTheProjectName ifFalse: [^false].
	actionBlock value: self copyOutDetails.
	self delete.