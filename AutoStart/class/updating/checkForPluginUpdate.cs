checkForPluginUpdate
	| pluginVersion updateURL |
	World 
		ifNotNil: [
			World install.
			ActiveHand position: 100@100].
	HTTPClient isRunningInBrowser
		ifFalse: [^false].
	pluginVersion _ AbstractLauncher extractParameters
		at: (SmalltalkImage current platformName copyWithout: Character space) asUppercase
		ifAbsent: [^false].
	updateURL _ AbstractLauncher extractParameters
		at: 'UPDATE_URL'
		ifAbsent: [^false].
	^SystemVersion check: pluginVersion andRequestPluginUpdate: updateURL