replaceTallSubmorphsByThumbnails
	|  itsThumbnail heightForThumbnails maxHeightToAvoidThumbnailing maxWidthForThumbnails |
	heightForThumbnails _ self heightForThumbnails.
	maxHeightToAvoidThumbnailing _ self maxHeightToAvoidThumbnailing.
	maxWidthForThumbnails _ self maximumThumbnailWidth.
	self submorphs do:
		[:aMorph |
			itsThumbnail _ aMorph representativeNoTallerThan: maxHeightToAvoidThumbnailing norWiderThan: maxWidthForThumbnails thumbnailHeight: heightForThumbnails.
			(aMorph == itsThumbnail)
				ifFalse:
					[self replaceSubmorph: aMorph by: itsThumbnail]]