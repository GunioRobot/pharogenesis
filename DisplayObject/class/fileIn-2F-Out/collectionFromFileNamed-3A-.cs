collectionFromFileNamed: fileName 
	"Answer a collection of Forms read from the external file 
	named fileName. The file format is: fileCode, {depth, extent, offset, bits}."
	| file fileCode coll |
	file _ FileStream oldFileNamed: fileName.
	file binary; readOnly.
	fileCode _ file next.
	fileCode = 1 ifTrue: [^ Array with: (self new readFromOldFile: file)].
	fileCode = 2 ifFalse: [self halt].
	coll _ OrderedCollection new.
	[file atEnd] whileFalse: [coll add: (self new readFrom: file)].
	file close.
	^ coll