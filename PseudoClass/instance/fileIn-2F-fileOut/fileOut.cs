fileOut
	| f |
	f := (FileStream newFileNamed: self name,'.st').
	self fileOutOn: f.
	self needsInitialize ifTrue:[
		f cr; nextChunkPut: self name,' initialize'.
	].
	f close