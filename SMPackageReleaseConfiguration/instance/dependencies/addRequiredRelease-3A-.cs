addRequiredRelease: aRelease
	"Add <aRelease> as a required release. The release added
	can not indirectly refer back to this release."
	
	(self isCircular: aRelease) ifTrue: [self error: 'Circular dependencies not allowed.'].
	requiredReleases := requiredReleases copyWith: aRelease.
	^aRelease