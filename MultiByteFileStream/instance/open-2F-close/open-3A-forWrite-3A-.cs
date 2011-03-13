open: fileName forWrite: writeMode 
	| result |
	result := super open: fileName forWrite: writeMode.
	result ifNotNil: [
			converter ifNil: [converter := UTF8TextConverter new].
			self detectLineEndConvention].
	^result