createFromVFBFile: filename
	"Read in a mesh from the vfb file"

	| aFile result |
	aFile _ (StandardFileStream readOnlyFileNamed: filename) binary.
	result := self createFromVFBStream: aFile.
	aFile close.
	^result