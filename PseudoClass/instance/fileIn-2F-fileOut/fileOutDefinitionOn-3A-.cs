fileOutDefinitionOn: aStream
	self hasDefinition ifFalse:[^self].
	aStream nextChunkPut: self definition; cr.
	self hasComment ifTrue:[
		aStream cr; nextPut: $!; nextChunkPut: self name,' comment: '; cr.
		aStream nextChunkPut: self commentString printString.
	].