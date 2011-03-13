upgradePackageWithId: anUUIDString
	"Upgrade package to the latest published release for this Squeak version.
	Will raise error if there is no release installed, otherwise use
	#upgradeOrInstallPackageWithId: "

	| package |
	package := self packageWithId: anUUIDString.
	package ifNil: [self error: 'No package available with id: ''', anUUIDString, ''''].
	^package upgrade