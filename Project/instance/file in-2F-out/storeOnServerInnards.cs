storeOnServerInnards
	"Save to disk as an Export Segment.  Then put that file on the server I came from, as a new version.  Version is literal piece of file name.  Mime encoded and http encoded."

	| servers resp newName primaryServerDirectory serverVersionPair localDirectory localVersionPair myVersionNumber warning maxNumber |
	self assureIntegerVersion.

	"Find out what version"
	(servers _ self serverList) ifNil: [
		(primaryServerDirectory _ self findAFolderToStoreProjectIn) ifNotNil: [
			servers _ Array with: primaryServerDirectory.
			self storeNewPrimaryURL: primaryServerDirectory realUrl, '/'.
		].
	] ifNotNil: [
		primaryServerDirectory _ servers first.
	].
	localDirectory _ self squeakletDirectory.
	serverVersionPair _ self class mostRecent: self name onServer: primaryServerDirectory.
	localVersionPair _ self class mostRecent: self name onServer: localDirectory.
	maxNumber _ myVersionNumber _ self currentVersionNumber.
	ProgressNotification signal: '2:versionsDetected'.

	warning _ ''.
	myVersionNumber < serverVersionPair second ifTrue: [
		warning _ warning,'\There are newer version(s) on the server'.
		maxNumber _ maxNumber max: serverVersionPair second.
	].
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
	newName _ self versionedFileName.
	lastSavedAtSeconds _ Time totalSeconds.
	self exportSegmentFileName: newName directory: localDirectory.		
	ProgressNotification signal: '4:localSaveComplete'.	"3 is deep in export logic"

	primaryServerDirectory ifNotNil: [
		self
			writeFileNamed: newName 
			fromDirectory: localDirectory 
			toServer: primaryServerDirectory.
	].
	ProgressNotification signal: '9999 save complete'.

	"Later, store with same name on secondary servers.  Still can be race conditions.  All machines will go through the server list in the same order."
	"2 to: servers size do: [:aServer | aServer putFile: local named: newName]."
