updateViewer: aViewer forceToShow: aCategory
	| aPlayer aPosition newViewer oldOwner wasSticky barHeight |
	aPlayer _ aViewer scriptedPlayer.
	aPosition _ aViewer position.
	wasSticky _ aViewer isSticky.
	newViewer _ aViewer species new visible: false.
	barHeight _ aViewer submorphs first orientation == #vertical
		ifTrue:
			[aViewer submorphs first submorphs first height]
		ifFalse:
			[0].
	newViewer initializeFor: aPlayer barHeight: barHeight includeDismissButton: aViewer hasDismissButton.
	wasSticky ifTrue: [newViewer beSticky].
	oldOwner _ aViewer owner.
	oldOwner ifNotNil:
		[oldOwner replaceSubmorph: aViewer by: newViewer].
	
	"It has happened that old readouts are still on steplist.  We may see again!"

	newViewer position: aPosition.
	newViewer enforceTileColorPolicy.
	newViewer visible: true.
	newViewer world startSteppingSubmorphsOf: newViewer.
	newViewer layoutChanged