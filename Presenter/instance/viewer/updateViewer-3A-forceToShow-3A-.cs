updateViewer: aViewer forceToShow: aCategorySymbol
	"Update the given viewer to make sure it is in step with various possible changes in the outside world, and when reshowing it be sure it shows the given category"

	| aPlayer aPosition newViewer oldOwner wasSticky barHeight itsVocabulary aCategory categoryInfo |
	aCategory _ aCategorySymbol ifNotNil: [aViewer currentVocabulary translatedWordingFor: aCategorySymbol].
	categoryInfo _ aViewer categoryMorphs  asOrderedCollection collect:
		[:aMorph | aMorph categoryRestorationInfo].

	itsVocabulary _ aViewer currentVocabulary.
	aCategory ifNotNil: [(categoryInfo includes: aCategorySymbol) ifFalse: [categoryInfo addFirst: aCategorySymbol]].
	aPlayer _ aViewer scriptedPlayer.
	aPosition _ aViewer position.
	wasSticky _ aViewer isSticky.
	newViewer _ aViewer species new visible: false.
	barHeight _ aViewer submorphs first listDirection == #topToBottom
		ifTrue:
			[aViewer submorphs first submorphs first height]
		ifFalse:
			[0].
	Preferences viewersInFlaps ifTrue:
		[newViewer setProperty: #noInteriorThumbnail toValue: true].

	newViewer rawVocabulary: itsVocabulary.
	newViewer limitClass: aViewer limitClass.
	newViewer initializeFor: aPlayer barHeight: barHeight includeDismissButton: aViewer hasDismissButton showCategories: categoryInfo.
	wasSticky ifTrue: [newViewer beSticky].
	oldOwner _ aViewer owner.
	oldOwner ifNotNil:
		[oldOwner replaceSubmorph: aViewer by: newViewer].
	
	"It has happened that old readouts are still on steplist.  We may see again!"

	newViewer position: aPosition.
	newViewer enforceTileColorPolicy.
	newViewer visible: true.
	newViewer world ifNotNilDo: [:aWorld | aWorld startSteppingSubmorphsOf: newViewer].
	newViewer layoutChanged