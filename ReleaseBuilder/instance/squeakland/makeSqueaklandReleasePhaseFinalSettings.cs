makeSqueaklandReleasePhaseFinalSettings
	"ReleaseBuilder new makeSqueaklandReleasePhaseFinalSettings"

	| serverName serverURL serverDir updateServer highestUpdate newVersion |

	ProjectLauncher splashMorph: (FileDirectory default readOnlyFileNamed: 'scripts\SqueaklandSplash.morph') fileInObjectAndCode.

	"Dump all morphs so we don't hold onto anything"
	World submorphsDo:[:m| m delete].

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

	) do:[:spec|
		Preferences setPreference: spec first toValue: spec last].
	"Workaround for bug"
	Preferences enable: #readDocumentAtStartup.

	World color: (Color r: 0.9 g: 0.9 b: 1.0).

	"Clear all server entries"
	ServerDirectory serverNames do: [:each | ServerDirectory removeServerNamed: each].
	SystemVersion current resetHighestUpdate.

	"Add the squeakalpha update stream"
	serverName _ 'Squeakalpha'.
	serverURL _ 'squeakalpha.org'.
	serverDir _ serverURL , '/'.

	updateServer _ ServerDirectory new.
	updateServer
		server: serverURL;
		directory: 'updates/';
		altUrl: serverDir;
		user: 'sqland';
		password: nil.
	Utilities updateUrlLists addFirst: {serverName. {serverDir. }.}.

	"Add the squeakland update stream"
	serverName _ 'Squeakland'.
	serverURL _ 'squeakland.org'.
	serverDir _ serverURL , '/'.

	updateServer _ ServerDirectory new.
	updateServer
		server: serverURL;
		directory: 'public_html/updates/';
		altUrl: serverDir.
	Utilities updateUrlLists addFirst: {serverName. {serverDir. }.}.

	highestUpdate _ SystemVersion current highestUpdate.
	(self confirm: 'Reset highest update (' , highestUpdate printString , ')?')
		ifTrue: [SystemVersion current highestUpdate: 0].

	newVersion _ FillInTheBlank request: 'New version designation:' initialAnswer: 'Squeakland 3.8.' , highestUpdate printString. 
	SystemVersion newVersion: newVersion.
	(self confirm: self version , '
Is this the correct version designation?
If not, choose no, and fix it.') ifFalse: [^ self].