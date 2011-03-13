installPackageRelease
	"Install selected package or release.
	The cache is used."

	| item release |
	item := self selectedPackageOrRelease.
	item isPackageRelease
		ifTrue: [
			(item isPublished or: [self confirm: 'Selected release is not published yet, install anyway?'])
				ifTrue: [^self installPackageRelease: item]]
		ifFalse: [
			release := item lastPublishedReleaseForCurrentSystemVersion.
			release ifNil: [
				(self confirm: 'The package has no published release for your Squeak version, try releases for any Squeak version?')
					ifTrue: [
						release := item lastPublishedRelease.
						release ifNil: [
							(self confirm: 'The package has no published release at all, take the latest of the unpublished releases?')
								ifTrue: [release := item lastRelease]]]].
			release ifNotNil: [^self installPackageRelease: release]]