updateViewer: aViewer forceToShow: aCategory
	"Update the given viewer to make sure it is in step with various possible changes in the outside world, and when reshowing it be sure it shows the given category"

	| aPlayer aPosition newViewer oldOwner wasSticky barHeight cats |
	cats _ aViewer categoriesCurrentlyShowing asOrderedCollection.
	aCategory ifNotNil: [(cats includes: aCategory) ifFalse: [cats addFirst: aCategory]].
	aPlayer _ aViewer scriptedPlayer.
	aPosition _ aViewer position.
	wasSticky _ aViewer isSticky.
	newViewer _ aViewer species new visible: false.
	barHeight _ aViewer submorphs first listDirection == #topToBottom
		ifTrue:
			[aViewer submorphs first submorphs first height]
		ifFalse:
			[0].
	newViewer initializeFor: aPlayer barHeight: barHeight includeDismissButton: aViewer hasDismissButton showCategories: cats.
	wasSticky ifTrue: [newViewer beSticky].
	oldOwner _ aViewer owner.
	oldOwner ifNotNil:
		[oldOwner replaceSubmorph: aViewer by: newViewer].
	
	"It has happened that old readouts are still on steplist.  We may see again!"

	newViewer position: aPosition.
	newViewer enforceTileColorPolicy.
	newViewer visible: true.
	newViewer world doIfNotNil: [:aWorld | aWorld startSteppingSubmorphsOf: newViewer].
	newViewer layoutChanged