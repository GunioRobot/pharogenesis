noteInstalledPackageWithId: aPackageId autoVersion: aVersion
	"The package release was just successfully installed.
	Can be used to inform SM of an installation not been
	done using SM, even when the map isn't loaded."

	
^self noteInstalledPackageWithId: aPackageId
		autoVersion: aVersion
		name: '<unknown name>'