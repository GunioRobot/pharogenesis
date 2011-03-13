noteInstalledPackage: uuidString version: version
	"Mark a specific version of a package as installed.
	This method is called when replaying a logged installation
	from before SqueakMap 1.07. Such logged installations lacked
	a timestamp and a count. We take the current time and a
	count starting from -10000 and upwards. This should keep
	the sorting order correct."

	^self registry noteInstalledPackage: uuidString version: version