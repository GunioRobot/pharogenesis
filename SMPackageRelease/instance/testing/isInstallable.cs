isInstallable
	"Answer if there is any installer for me.
	This depends typically on the filename of
	the download url, but can in the future
	depend on other things too.
	It does *not* say if the release is installed or not."

	^SMInstaller isInstallable: self