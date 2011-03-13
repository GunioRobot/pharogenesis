fromFileName: fullName 
	"Reconstitute a Morph from the file, presumed to be represent a Morph
	saved via the SmartRefStream mechanism, and open it in an
	appropriate Morphic world"
	| aFileStream morphOrList |
	aFileStream := (MultiByteBinaryOrTextStream with: (FileStream readOnlyFileNamed: fullName) binary contentsOfEntireFile) binary reset.
	morphOrList := aFileStream fileInObjectAndCode.
	morphOrList := self postLoad.
	ActiveWorld addMorphsAndModel: morphOrList