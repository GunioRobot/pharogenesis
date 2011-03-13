openFromSaveFileOn: anEToyHolder
	"Like openOn, but first fleshes out the scaffolding that needs to come from the image rather than from the save-file"

	BookMorph turnOffSoundWhile:
		[anEToyHolder initializeScaffoldingContentsForReloadedEToy].
	^ self openOn: anEToyHolder