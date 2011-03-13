openMorphFromFile
	"Reconstitute a Morph from the selected file, presumed to be represent a Morph saved
	via the SmartRefStream mechanism, and open it in an appropriate Morphic world"

 	| aFileStream morphOrList |
	Smalltalk verifyMorphicAvailability ifFalse: [^ self].

	aFileStream _ directory readOnlyFileNamed: self fullName.
	morphOrList _ aFileStream fileInObjectAndCode.
	(morphOrList isKindOf: SqueakPage) ifTrue: [morphOrList _ morphOrList contentsMorph].
	Smalltalk isMorphic
		ifTrue: [Display getCurrentMorphicWorld addMorphsAndModel: morphOrList]
		ifFalse:
			[morphOrList isMorph ifFalse: [^ self errorMustBeMorph].
			morphOrList openInWorld]