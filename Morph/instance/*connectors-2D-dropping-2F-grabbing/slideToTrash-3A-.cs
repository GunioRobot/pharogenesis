slideToTrash: evt
	"Perhaps slide the receiver across the screen to a trash can and make it disappear into it.  In any case, remove the receiver from the screen."

	| aForm trash startPoint endPoint morphToSlide |
	((self renderedMorph == Utilities scrapsBook) or: [self renderedMorph isKindOf: TrashCanMorph]) ifTrue:
		[self delete.  ^ self].
	Preferences slideDismissalsToTrash ifTrue:
		[morphToSlide _ self representativeNoTallerThan: 200 norWiderThan: 200 thumbnailHeight: 100.
		aForm _ morphToSlide imageForm offset: (0@0).
		trash _ ActiveWorld
			findDeepSubmorphThat:
				[:aMorph | (aMorph isKindOf: TrashCanMorph) and:
					[aMorph topRendererOrSelf owner == ActiveWorld]]
			ifAbsent:
				[trash _ TrashCanMorph new.
				trash position: ActiveWorld bottomLeft - (0 @ (trash extent y + 26)).
				trash openInWorld.
				trash].
		endPoint _ trash fullBoundsInWorld center.
		startPoint _ self topRendererOrSelf fullBoundsInWorld center - (aForm extent // 2)].
	self delete.
	ActiveWorld displayWorld.
	Preferences slideDismissalsToTrash ifTrue:
		[aForm slideFrom: startPoint to: endPoint nSteps: 12 delay: 15].
	Utilities addToTrash: self