primitiveDirectoryLookup
	| index pathName pathNameIndex pathNameSize status entryName entryNameSize createDate modifiedDate dirFlag fileSize okToList |
	self var: 'entryName' declareC: 'char entryName[256]'.
	self var: 'pathNameIndex' type: 'char *'.
	self var: 'fileSize' type: 'squeakFileOffsetType'.
	self export: true.
	index _ interpreterProxy stackIntegerValue: 0.
	pathName _ interpreterProxy stackValue: 1.
	(interpreterProxy isBytes: pathName)
		ifFalse: [^ interpreterProxy primitiveFail].
	pathNameIndex _ interpreterProxy firstIndexableField: pathName.
	pathNameSize _ interpreterProxy byteSizeOf: pathName.
	"If the security plugin can be loaded, use it to check for permission. 
	If not, assume it's ok"
	sCLPfn ~= 0
		ifTrue: [okToList _ self cCode: ' ((int (*) (char *, int)) sCLPfn)(pathNameIndex, pathNameSize)']
		ifFalse: [okToList _ true].
	okToList
		ifTrue: [status _ self cCode: 'dir_Lookup(
				(char *) pathNameIndex, pathNameSize, index,
				entryName, &entryNameSize, &createDate, &modifiedDate,
				&dirFlag, &fileSize)']
		ifFalse: [status _ DirNoMoreEntries].
	interpreterProxy failed
		ifTrue: [^ nil].
	status = DirNoMoreEntries
		ifTrue: ["no more entries; return nil"
			interpreterProxy pop: 3.
			"pop pathName, index, rcvr"
			interpreterProxy push: interpreterProxy nilObject.
			^ nil].
	status = DirBadPath
		ifTrue: [^ interpreterProxy primitiveFail].
	"bad path"
	interpreterProxy pop: 3.
	"pop pathName, index, rcvr"
	interpreterProxy
		push: (self
				makeDirEntryName: entryName
				size: entryNameSize
				createDate: createDate
				modDate: modifiedDate
				isDir: dirFlag
				fileSize: fileSize)