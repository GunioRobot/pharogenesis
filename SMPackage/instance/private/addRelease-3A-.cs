addRelease: aRelease
	"Add the release. Make sure package is set."

	releases add: aRelease.
	aRelease package: self.
	^aRelease