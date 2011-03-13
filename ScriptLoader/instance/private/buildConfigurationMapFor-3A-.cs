buildConfigurationMapFor: packageNames

	| configurationMap version depArray |
	configurationMap := MCConfiguration new.
	configurationMap repositories
		add: self repository;
		add: self inboxRepository.

	packageNames do: [:packageName |
		version := self loadVersionFromFileNamed: packageName.
		depArray := { version package name. version info name. version info id asString. }.
		configurationMap dependencies add: (MCConfiguration dependencyFromArray: depArray)].
	^configurationMap