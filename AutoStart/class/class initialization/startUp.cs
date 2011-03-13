startUp
	| startupParameters launchers |
	startupParameters _ AbstractLauncher extractParameters.
	launchers _ self installedLaunchers collect: [:launcher |
		launcher new].
	launchers do: [:launcher |
		launcher parameters: startupParameters].
	launchers do: [:launcher |
		Smalltalk at: #WorldState ifPresent: [ :ws | ws addDeferredUIMessage: [launcher startUp]]]