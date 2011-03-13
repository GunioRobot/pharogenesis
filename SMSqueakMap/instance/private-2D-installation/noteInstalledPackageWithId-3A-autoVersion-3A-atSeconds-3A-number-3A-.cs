noteInstalledPackageWithId: uuidString autoVersion: version atSeconds: time number: num
	"Mark a package as installed in the Dictionary.
	This method is called when replaying a logged installation.
	<time> is the point in time as totalSeconds of the installation.
	<num> is the installCount of the installation.
	This method is typically called from a doIt in the changelog
	in order to try to keep track of packages installed."

	^self registry noteInstalledPackageWithId: uuidString autoVersion: version atSeconds: time number: num