viewByIcon
	"The receiver has been being viewed in some constrained layout view; now restore it to its normal x-y-layout view"

	|  oldSubs |
	self showingListView
		ifTrue:
			[oldSubs _ submorphs.
			self removeAllMorphs.
			self layoutPolicy: nil.
			oldSubs do:
				[:aSubmorph |
					self addMorphBack:  aSubmorph objectRepresented].
			self restoreBoundsOfSubmorphs.
			self removeProperty: #showingListView]
		ifFalse:
			[self autoLineLayout == true ifTrue: [self toggleAutoLineLayout]]