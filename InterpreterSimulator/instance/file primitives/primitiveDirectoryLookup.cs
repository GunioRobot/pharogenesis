primitiveDirectoryLookup
	| index pathName array result |
	index _ self stackIntegerValue: 0.
	pathName _ (self stringOf: (self stackValue: 1)).
	
	successFlag ifFalse: [
		^self primitiveFail.
	].

	array _ FileDirectory default primLookupEntryIn: pathName index: index.

	array == nil ifTrue: [
		self pop: 3.
		self push: nilObj.
		^array.
	].
	array == #badDirectoryPath ifTrue: [
		^self primitiveFail.
	].

	result _ self makeDirEntryName: (array at: 1) size: (array at: 1) size
				createDate: (array at: 2) modDate: (array at: 3)
				isDir: (array at: 4)  fileSize: (array at: 5).
	self pop: 3.
	self push: result.
