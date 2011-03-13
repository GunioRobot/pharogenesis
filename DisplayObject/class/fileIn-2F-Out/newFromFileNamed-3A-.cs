newFromFileNamed: fileName 
	"Answer a Form with bitmap initialized from the external file 
	named fileName. The file format is: fileCode, depth, extent, offset, bits."
	| newForm file fileCode |
	file _ FileStream oldFileNamed: fileName.
	file binary; readOnly.
	fileCode _ file next.
	fileCode = 1 ifTrue: [^ self new readFromOldFile: file].
	fileCode = 2 ifFalse: [self halt].
	newForm _ self new readFrom: file.
	file close.
	^ newForm