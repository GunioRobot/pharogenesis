basicStoreVersion: aVersion
	| url |
	url _ self uploadVersion: aVersion.
	self releaseVersion: aVersion url: url