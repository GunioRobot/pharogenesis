availablePackages
	"Answer all packages that are old or not installed."

	^self packages select: [:package | package isAvailable]