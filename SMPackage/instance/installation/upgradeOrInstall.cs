upgradeOrInstall
	"Upgrade to or install the latest newer published version for this version of Squeak."

	| installed |
	installed := self installedRelease.
	installed
		ifNil: [^self install]
		ifNotNil: [^installed upgrade]