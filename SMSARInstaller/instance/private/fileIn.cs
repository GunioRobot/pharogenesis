fileIn

	Smalltalk at: #SARInstaller ifPresentAndInMemory: [:installer |
		(installer directory: dir fileName: fileName) fileIn. ^self].
	self error: 'SAR support not installed in image, can not install.'