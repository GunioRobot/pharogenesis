initialiseModule
	self export: true.
	sCCPfn _ interpreterProxy ioLoadFunction: 'secCanCreatePathOfSize' From: 'SecurityPlugin'.
	sCDPfn _ interpreterProxy ioLoadFunction: 'secCanDeletePathOfSize' From: 'SecurityPlugin'.
	sCGFTfn _ interpreterProxy ioLoadFunction: 'secCanGetFileTypeOfSize' From: 'SecurityPlugin'.
	sCLPfn _ interpreterProxy ioLoadFunction: 'secCanListPathOfSize' From: 'SecurityPlugin'.
	sCSFTfn _ interpreterProxy ioLoadFunction: 'secCanSetFileTypeOfSize' From: 'SecurityPlugin'.
	sDFAfn _ interpreterProxy ioLoadFunction: 'secDisableFileAccess' From: 'SecurityPlugin'.
	sCDFfn _ interpreterProxy ioLoadFunction: 'secCanDeleteFileOfSize' From: 'SecurityPlugin'.
	sCOFfn _ interpreterProxy ioLoadFunction: 'secCanOpenFileOfSizeWritable' From: 'SecurityPlugin'.
	sCRFfn _ interpreterProxy ioLoadFunction: 'secCanRenameFileOfSize' From: 'SecurityPlugin'.
	sHFAfn _ interpreterProxy ioLoadFunction: 'secHasFileAccess' From: 'SecurityPlugin'.
	^self cCode: 'sqFileInit()' inSmalltalk:[true]