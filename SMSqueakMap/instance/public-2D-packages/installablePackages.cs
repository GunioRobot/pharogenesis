installablePackages
	"Answer all packages that can be (auto)installed -
	we have installers that can install them."

	^self packages select: [:package | package isInstallable]