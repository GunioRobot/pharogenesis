wantsToBeDroppedInto: aMorph
	"Only into PasteUps that are not part bins"
	^aMorph isPlayfieldLike and:[aMorph isPartsBin not]