noteInstalledPackage: aPackage autoVersion: aVersion
	"Mark that the package release was just successfully installed.
	Can be used to inform SM of an installation not been done using SM."

	
^self noteInstalledPackageWithId: aPackage id asString
		autoVersion: aVersion
		name: aPackage name