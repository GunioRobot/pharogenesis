installPackageRelease
	"Install selected package or release.
	The cache is used."

	| item release |
	item _ self selectedPackageOrRelease.
	item isPackageRelease
		ifTrue: [
			(item isPublished or: [self confirm: 'Selected release is not published yet, install anyway?'])
				ifTrue: [^self installPackageRelease: item]]
		ifFalse: [
			release _ item lastPublishedReleaseForCurrentSystemVersion.
			release ifNil: [
				(self confirm: 'The package has no published release for your Squeak version, try releases for any Squeak version?')
					ifTrue: [
						release _ item lastPublishedRelease.
						release ifNil: [
							(self confirm: 'The package has no published release at all, take the latest of the unpublished releases?')
								ifTrue: [release _ item lastRelease]]]].
			release ifNotNil: [^self installPackageRelease: release]]