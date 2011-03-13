markInstalled: uuid version: version time: time counter: num
	"Private. Mark the installation. SM2 uses an Association
	to distinguish the automatic version from old versions."


	| installs |
	installedPackages ifNil: [installedPackages := Dictionary new].
	installs := installedPackages at: uuid
				ifAbsent: [installedPackages at: uuid put: OrderedCollection new].
	installs add:
		(Array with: 2->version
				with: time
				with: num)