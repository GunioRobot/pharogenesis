storeLocallyInnards
	"Save the project to the local disk only"

	| resp newName localDirectory localVersionPair myVersionNumber warning maxNumber |
	self assureIntegerVersion.

	"Find out what version"

	localDirectory _ FileDirectory default.
	localVersionPair _ self class mostRecent: self name onServer: localDirectory.
	maxNumber _ myVersionNumber _ self currentVersionNumber.
	ProgressNotification signal: '2:versionsDetected'.

	warning _ ''.
	myVersionNumber < localVersionPair second ifTrue: [
		warning _ warning,'\There are newer version(s) in the local directory'.
		maxNumber _ maxNumber max: localVersionPair second.
	].
	"8 Nov 2000 - only check on the first attempt to publish"
	myVersionNumber = 0 ifTrue: [
		warning isEmpty ifFalse: [
			myVersionNumber = 0 ifTrue: [
				warning _ warning,'\THIS PROJECT HAS NEVER BEEN SAVED'
			].
			warning _ 'WARNING', '\Project: ',self name,warning.
			resp _ (PopUpMenu labels: 'Store anyway\Cancel' withCRs) startUpWithCaption: 
				(warning, '\Please cancel, rename this project, and see what is there.') withCRs.
				resp ~= 1 ifTrue: [^ nil]
		].
	].
	version _ self bumpVersion: maxNumber.

	"write locally - now zipped automatically"

	newName _ FillInTheBlank 
			request: 'File name?' 
			initialAnswer: self versionedFileName.
	newName isEmpty ifTrue: [^ self beep].

	lastSavedAtSeconds _ Time totalSeconds.
	self exportSegmentFileName: newName directory: localDirectory.		
	ProgressNotification signal: '4:localSaveComplete'.	"3 is deep in export logic"

	ProgressNotification signal: '9999 save complete'.


