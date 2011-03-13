upgradeOrInstallPackageWithId: anUUIDString asOf: aTimeStamp
	"Upgrade package (or install) to the latest published release as it was
	on <aTimeStamp> for this Squeak version. This ensures that the same
	release will be installed (for all Squeak versions) as when it was tested."

	| package |
	package := self packageWithId: anUUIDString.
	package ifNil: [self error: 'No package available with id: ''', anUUIDString, ''''].
	^package upgradeOrInstall