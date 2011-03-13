versionCode
    "Answer a number representing the 'version' of the ReferenceStream facility; this is stashed at the beginning of ReferenceStreams, as a secondary versioning mechanism (the primary one is the fileTypeCode).   At present, it serves for information only, and is not checked for compatibility at reload time, but could in future be used to branch to variant code. 12/2/92 sw"

	" 1 = "
	" 2 = HyperSqueak.  PathFromHome used for Objs outside the tree.  SqueakSupport SysLibrary for shared globals like Display and StrikeFonts.  File has version number, class structure, then an IncomingObjects manager.  8/16/96 tk"
	^ 2