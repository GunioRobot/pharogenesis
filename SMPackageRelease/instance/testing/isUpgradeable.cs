isUpgradeable
	"Answer if there is any installer that can upgrade me.
	This depends typically on the filename of
	the download url, but can in the future
	depend on other things too.
	It does *not* say if the package is installed or not
	or if there is a newer version available or not."

	^SMInstaller isUpgradeable: self