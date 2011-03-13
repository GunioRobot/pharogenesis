parentReleaseFor: aPackageRelease
	"If there is none (the given release is automaticVersion '1'), return nil."

	| previousVersion |
	previousVersion := aPackageRelease automaticVersion previous.
	^releases detect: [:r | r automaticVersion = previousVersion] ifNone: [nil]