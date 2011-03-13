upgrade
	"Upgrade to the latest newer published version for this version of Squeak."

	| installed |
	installed := self installedRelease.
	installed
		ifNil: [self error: 'No release installed, can not upgrade.']
		ifNotNil: [^installed upgrade]