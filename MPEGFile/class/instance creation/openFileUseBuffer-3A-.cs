openFileUseBuffer: aPath 
	| bar bytes |
	bar _ StandardFileStream oldFileNamed: aPath.
	bar binary.
	bytes _ bar contents.
	^self new openBuffer: bytes