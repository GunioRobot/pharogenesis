clearInstalledPackages
	"Simply clear the dictionary with information on installed packages.
	Might be good if things get corrupted etc. Also see
	SMSqueakMap class>>recreateInstalledPackagesFromChangeLog"

	installedPackages _ nil.
	installCounter _ 0