collectionFromFileNamed: fileName 
	"Answer a collection of Forms read from the external file 
	named fileName. The file format is: fileCode, {depth, extent, offset, bits}."

	| formList f fileCode |
	formList _ OrderedCollection new.
	f _ (FileStream readOnlyFileNamed: fileName) binary.
	fileCode _ f next.
	fileCode = 1
		ifTrue: [
			[f atEnd] whileFalse: [formList add: (self new readFromOldFormat: f)]]
		ifFalse: [
			fileCode = 2 ifFalse: [self error: 'unknown Form file format'. ^ formList].
			[f atEnd] whileFalse: [formList add: (self new readFrom: f)]].
	f close.
	^ formList
