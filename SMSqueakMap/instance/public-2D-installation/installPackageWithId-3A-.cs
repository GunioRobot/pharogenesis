installPackageWithId: anUUIDString
	"Look up and install the latest release of the given package.	

	Note: This method should not be used anymore.
	Better to specify a specific release."

	| package |
	package := self packageWithId: anUUIDString.
	package ifNil: [self error: 'No package available with id: ''', anUUIDString, ''''].
	^self installPackage: package