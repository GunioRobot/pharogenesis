onceAgainDismiss: aMorph
	"Occasioned by a redo of a dismiss-via-halo"

	aMorph dismissMorph.
	Preferences preserveTrash ifTrue: 
		[Preferences slideDismissalsToTrash
			ifTrue:[aMorph slideToTrash: nil]
			ifFalse:[TrashCanMorph moveToTrash: aMorph]]
