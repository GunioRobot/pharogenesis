primitiveDirectoryLookup

	| index pathName pathNameIndex pathNameSize status entryName entryNameSize createDate modifiedDate dirFlag fileSize |
	self var: 'entryName' declareC: 'char entryName[256]'.
	index _ self stackIntegerValue: 0.
	pathName _ self stackValue: 1.
	self success: (self isBytes: pathName).
	successFlag ifTrue: [
		pathNameIndex _ pathName + BaseHeaderSize.
		pathNameSize _ self lengthOf: pathName.
	].
	successFlag ifTrue: [
		status _ self cCode:
			'dir_Lookup(
				(char *) pathNameIndex, pathNameSize, index,
				entryName, &entryNameSize, &createDate, &modifiedDate,
				&dirFlag, &fileSize)'.
		status = DirNoMoreEntries ifTrue: [
			"no more entries; return nil"
			self pop: 3.  "pop pathName, index, rcvr"
			self push: nilObj.
			^ nil
		].
		status = DirBadPath ifTrue: [ ^ self primitiveFail ].  "bad path"
	].
	successFlag ifTrue: [
		self pop: 3.  "pop pathName, index, rcvr"
		self push:
			(self makeDirEntryName: entryName size: entryNameSize
				createDate: createDate modDate: modifiedDate
				isDir: dirFlag fileSize: fileSize).
	].