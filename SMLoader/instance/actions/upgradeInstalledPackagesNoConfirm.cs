upgradeInstalledPackagesNoConfirm
	"Tries to upgrade all installed packages to the latest published release for this
	version of Squeak. No confirmation on each upgrade."

	^ self upgradeInstalledPackagesConfirm: false