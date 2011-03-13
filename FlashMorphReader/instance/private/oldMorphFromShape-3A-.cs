oldMorphFromShape: objectIndex
	"Return an existing character morph from the given object index."
	| prototype |
	prototype := shapes at: objectIndex ifAbsent:[nil].
	"prototype ifNil:[prototype := buttons at: objectIndex ifAbsent:[nil]]."
	prototype ifNil:[Transcript cr; nextPutAll:'No shape for '; print: objectIndex; nextPutAll:' in frame '; print: frame; endEntry].
	^prototype