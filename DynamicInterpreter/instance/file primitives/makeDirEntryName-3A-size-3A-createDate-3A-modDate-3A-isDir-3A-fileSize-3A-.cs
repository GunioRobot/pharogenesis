makeDirEntryName: entryName size: entryNameSize
	createDate: createDate modDate: modifiedDate
	isDir: dirFlag fileSize: fileSize

	| modDateOop createDateOop nameString results |
	self var: 'entryName' declareC: 'char *entryName'.

	"allocate storage for results, remapping newly allocated
	 oops in case GC happens during allocation"
	self pushRemappableOop:
		(self instantiateClass: (self splObj: ClassArray) indexableSize: 5).
	self pushRemappableOop:
		(self instantiateClass: (self splObj: ClassString) indexableSize: entryNameSize)..
	self pushRemappableOop: (self positive32BitIntegerFor: createDate).
	self pushRemappableOop: (self positive32BitIntegerFor: modifiedDate).

	modDateOop   _ self popRemappableOop.
	createDateOop _ self popRemappableOop.
	nameString    _ self popRemappableOop.
	results         _ self popRemappableOop.

	"copy name into Smalltalk string"
	0 to: entryNameSize - 1 do: [ :i |
		self storeByte: i ofObject: nameString withValue: (entryName at: i).
	].

	self storePointer: 0 ofObject: results withValue: nameString.
	self storePointer: 1 ofObject: results withValue: createDateOop.
	self storePointer: 2 ofObject: results withValue: modDateOop.
	dirFlag
		ifTrue: [ self storePointer: 3 ofObject: results withValue: trueObj ]
		ifFalse: [ self storePointer: 3 ofObject: results withValue: falseObj ].
	self storePointer: 4 ofObject: results
		withValue: (self integerObjectOf: fileSize).
	^ results
