fromFileName: fullName
	"Reconstitute a Morph from the file, presumed to be represent a Morph saved
	via the SmartRefStream mechanism, and open it in an appropriate Morphic world"

 	| aFileStream morphOrList |
	aFileStream _ (MultiByteBinaryOrTextStream with: ((FileStream readOnlyFileNamed: fullName) binary contentsOfEntireFile)) binary reset.
	morphOrList _ aFileStream fileInObjectAndCode.
	(morphOrList isKindOf: SqueakPage) ifTrue: [morphOrList _ morphOrList contentsMorph].
	Smalltalk isMorphic
		ifTrue: [ActiveWorld addMorphsAndModel: morphOrList]
		ifFalse:
			[morphOrList isMorph ifFalse: [self inform: 'Can only load a single morph
into an mvc project via this mechanism.'].
			morphOrList openInWorld]