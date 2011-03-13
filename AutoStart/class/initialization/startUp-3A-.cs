startUp: resuming
	"The image is either being newly started (resuming is true), or it's just been snapshotted.
	If this has just been a snapshot, skip all the startup stuff."

	| startupParameters launchers |
	self active ifTrue: [^self].
	self active: true.
	resuming ifFalse: [^self].

	HTTPClient determineIfRunningInBrowser.
	startupParameters := AbstractLauncher extractParameters.
	(startupParameters includesKey: 'apiSupported' asUppercase )
		ifTrue: [
			HTTPClient browserSupportsAPI: ((startupParameters at: 'apiSupported' asUppercase) asUppercase = 'TRUE').
			HTTPClient isRunningInBrowser
				ifFalse: [HTTPClient isRunningInBrowser: true]].
	self checkForUpdates
		ifTrue: [^self].
	self checkForPluginUpdate.
	launchers := self installedLaunchers collect: [:launcher |
		launcher new].
	launchers do: [:launcher |
		launcher parameters: startupParameters].
	launchers do: [:launcher |
		Smalltalk at: #WorldState ifPresent: [ :ws | ws addDeferredUIMessage: [launcher startUp]]]