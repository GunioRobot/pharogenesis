makeDirEntryName: entryName size: entryNameSize
	createDate: createDate modDate: modifiedDate
	isDir: dirFlag fileSize: fileSize

	| modDateOop createDateOop nameString results stringPtr fileSizeOop |
	self var: 'entryName' declareC: 'char *entryName'.
	self var: 'stringPtr' declareC:'char *stringPtr'.
	self var: 'fileSize' declareC:'squeakFileOffsetType fileSize'.

	"allocate storage for results, remapping newly allocated
	 oops in case GC happens during allocation"
	interpreterProxy pushRemappableOop:
		(interpreterProxy instantiateClass: (interpreterProxy classArray) indexableSize: 5).
	interpreterProxy pushRemappableOop:
		(interpreterProxy instantiateClass: (interpreterProxy classString) indexableSize: entryNameSize)..
	interpreterProxy pushRemappableOop: 
		(interpreterProxy positive32BitIntegerFor: createDate).
	interpreterProxy pushRemappableOop: 
		(interpreterProxy positive32BitIntegerFor: modifiedDate).
	interpreterProxy pushRemappableOop:
		(interpreterProxy positive64BitIntegerFor: fileSize).

	fileSizeOop   _ interpreterProxy popRemappableOop.
	modDateOop   _ interpreterProxy popRemappableOop.
	createDateOop _ interpreterProxy popRemappableOop.
	nameString    _ interpreterProxy popRemappableOop.
	results         _ interpreterProxy popRemappableOop.

	"copy name into Smalltalk string"
	stringPtr _ interpreterProxy firstIndexableField: nameString.
	0 to: entryNameSize - 1 do: [ :i |
		stringPtr at: i put: (entryName at: i).
	].

	interpreterProxy storePointer: 0 ofObject: results withValue: nameString.
	interpreterProxy storePointer: 1 ofObject: results withValue: createDateOop.
	interpreterProxy storePointer: 2 ofObject: results withValue: modDateOop.
	dirFlag
		ifTrue: [ interpreterProxy storePointer: 3 ofObject: results withValue: interpreterProxy trueObject ]
		ifFalse: [ interpreterProxy storePointer: 3 ofObject: results withValue: interpreterProxy falseObject ].
	interpreterProxy storePointer: 4 ofObject: results withValue: fileSizeOop.
	^ results