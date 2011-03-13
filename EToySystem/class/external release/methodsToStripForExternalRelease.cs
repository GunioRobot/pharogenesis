methodsToStripForExternalRelease
	"Answer a list of triplets #(className, class/instance, methodName) of methods to be stripped in an external release."
	^ #(
		(EToyHolder			instance	initializeScaffoldingContentsForFreshEToy)
		(EToyHolder			instance	cedarText)
		(EToyHolder			instance	kayaText)
		(EToyHolder			instance	scaffoldingImagineersStrings)

		(EToyParameters		instance	initializein:)

		(EToyPlayer			instance	initializeFor:inWorld:)
		(EToyPlayer			class		openFrontCoverFor:)

		(EToySystem			class		serverUrls)
		(EToySystem			class		eToyDoItStrings)
		(EToySystem			class		loadPurpleWalt)	
		(EToySystem			class		openImagineeringStudio)	
		(EToySystem			class		readCollagePic)	
		(EToySystem			class		prepareRelease)	
		(EToySystem			class		previewEToysOn:)

		(EToyWorld			instance	createFrontCover)
		(EToyWorld			instance	exitFromCover)
		(EToyWorld			instance	scanServerForEToys)

		(ScreenController	class		initializeOpenMenuForInternalUse)
		(ScreenController	instance	openImagineeringStudio)
		(ScreenController	instance	openEToy)
		(ScreenController	instance	openEToyPanel)
		)