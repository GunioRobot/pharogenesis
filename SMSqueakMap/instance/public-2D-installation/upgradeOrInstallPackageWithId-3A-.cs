upgradeOrInstallPackageWithId: anUUIDString
	"Upgrade package (or install) to the latest published release for this Squeak version."

	| package |
	package := self packageWithId: anUUIDString.
	package ifNil: [self error: 'No package available with id: ''', anUUIDString, ''''].
	^package upgradeOrInstall