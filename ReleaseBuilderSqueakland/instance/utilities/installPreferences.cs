installPreferences

	#(
		(honorDesktopCmdKeys false)
		(warnIfNoChangesFile false)
		(warnIfNoSourcesFile false)
		(showDirectionForSketches true)
		(menuColorFromWorld false)
		(unlimitedPaintArea true)
		(useGlobalFlaps false)
		(mvcProjectsAllowed false)
		(projectViewsInWindows false)
		(automaticKeyGeneration true)
		(securityChecksEnabled true)
		(showSecurityStatus false)
		(startInUntrustedDirectory true)
		(warnAboutInsecureContent false)
		(promptForUpdateServer false)
		(fastDragWindowForMorphic false)

		(externalServerDefsOnly true)
		(expandedFormat false)
		(allowCelesteTell false)
		(eToyFriendly true)
		(eToyLoginEnabled true)
		(magicHalos true)
		(mouseOverHalos true)
		(biggerHandles false)
		(selectiveHalos true)
		(includeSoundControlInNavigator true)
		(readDocumentAtStartup true)
		(preserveTrash true)
		(slideDismissalsToTrash true)
		(propertySheetFromHalo true)

	) do:[:spec|
		Preferences setPreference: spec first toValue: spec last].
	"Workaround for bug"
	Preferences enable: #readDocumentAtStartup.
