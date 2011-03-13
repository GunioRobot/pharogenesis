showPageTurningFeedbackFromOrigin: oldOrigin ascending: ascending
	(PageFlipSoundOn and: [oldOrigin ~~ nil])
		ifTrue:
			[Display fadeImageHorFine: currentPage imageForm at: oldOrigin]