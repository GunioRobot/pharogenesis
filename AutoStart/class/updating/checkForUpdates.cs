checkForUpdates
	| availableUpdate updateServer |
	World 
		ifNotNil: [
			World install.
			ActiveHand position: 100@100].
	HTTPClient isRunningInBrowser
		ifFalse: [^self processUpdates].
	availableUpdate _ (AbstractLauncher extractParameters
		at: 'UPDATE'
		ifAbsent: [''] ) asInteger.
	availableUpdate
		ifNil: [^false].
	updateServer _ AbstractLauncher extractParameters
		at: 'UPDATESERVER'
		ifAbsent: [AbstractLauncher extractParameters
		at: 'UPDATE_SERVER'
		ifAbsent: ['Squeakland']].
	Utilities setUpdateServer: updateServer.
	^SystemVersion checkAndApplyUpdates: availableUpdate