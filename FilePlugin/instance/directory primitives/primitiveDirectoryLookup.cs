primitiveDirectoryLookup

	| index pathName pathNameIndex pathNameSize status entryName entryNameSize createDate modifiedDate dirFlag fileSize |
	self var: 'entryName' declareC: 'char entryName[256]'.
	self var: 'pathNameIndex' type: 'char *'.
	self export: true.
	index _ interpreterProxy stackIntegerValue: 0.
	pathName _ interpreterProxy stackValue: 1.
	(interpreterProxy isBytes: pathName) ifFalse:[^interpreterProxy primitiveFail].
	pathNameIndex _ interpreterProxy firstIndexableField: pathName.
	pathNameSize _ interpreterProxy byteSizeOf: pathName.

	status _ self cCode:
			'dir_Lookup(
				(char *) pathNameIndex, pathNameSize, index,
				entryName, &entryNameSize, &createDate, &modifiedDate,
				&dirFlag, &fileSize)'.

	interpreterProxy failed ifTrue:[^nil].

	status = DirNoMoreEntries ifTrue: [
		"no more entries; return nil"
		interpreterProxy pop: 3.  "pop pathName, index, rcvr"
		interpreterProxy push: interpreterProxy nilObject.
		^ nil
	].
	status = DirBadPath ifTrue: [ ^ interpreterProxy primitiveFail ].  "bad path"

	interpreterProxy pop: 3.  "pop pathName, index, rcvr"
	interpreterProxy push:
			(self makeDirEntryName: entryName size: entryNameSize
				createDate: createDate modDate: modifiedDate
				isDir: dirFlag fileSize: fileSize).