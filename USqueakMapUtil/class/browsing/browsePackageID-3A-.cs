browsePackageID: packageID
	"open a SqueakMap browser on the specified package ID"
	Smalltalk at: #SMLoader ifPresent: [ :smloaderClass |
		| loader |
		loader := smloaderClass open.
		loader selectedItemWrapper: (loader packageWrapperList detect: [:pw | pw
withoutListWrapper id = packageID])]
