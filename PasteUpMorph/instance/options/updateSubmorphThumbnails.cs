updateSubmorphThumbnails
	| thumbsUp itsThumbnail heightForThumbnails maxHeightToAvoidThumbnailing maxWidthForThumbnails |
	thumbsUp _ self alwaysShowThumbnail.
	heightForThumbnails _ self heightForThumbnails.
	maxHeightToAvoidThumbnailing _ self maxHeightToAvoidThumbnailing.
	maxWidthForThumbnails _ self maximumThumbnailWidth.
	self submorphs do:
		[:aMorph | thumbsUp
			ifTrue:
				[itsThumbnail _ aMorph representativeNoTallerThan: maxHeightToAvoidThumbnailing norWiderThan: maxWidthForThumbnails thumbnailHeight: heightForThumbnails.
				(aMorph == itsThumbnail)
					ifFalse:
						[self replaceSubmorph: aMorph by: itsThumbnail]]
			ifFalse:
				[(aMorph isKindOf: MorphThumbnail)
					ifTrue:
						[self replaceSubmorph: aMorph by: aMorph morphRepresented]]]