replaceTallSubmorphsByThumbnails
	"Any submorphs that seem to tall get replaced by thumbnails; their balloon text is copied over to the thumbnail"

	|  itsThumbnail heightForThumbnails maxHeightToAvoidThumbnailing maxWidthForThumbnails existingHelp |
	heightForThumbnails _ self heightForThumbnails.
	maxHeightToAvoidThumbnailing _ self maxHeightToAvoidThumbnailing.
	maxWidthForThumbnails _ self maximumThumbnailWidth.
	self submorphs do:
		[:aMorph |
			itsThumbnail _ aMorph representativeNoTallerThan: maxHeightToAvoidThumbnailing norWiderThan: maxWidthForThumbnails thumbnailHeight: heightForThumbnails.
			(aMorph == itsThumbnail)
				ifFalse:
					[existingHelp _ aMorph balloonText.
					self replaceSubmorph: aMorph by: itsThumbnail.
					existingHelp ifNotNil:
						[itsThumbnail setBalloonText: existingHelp]]]