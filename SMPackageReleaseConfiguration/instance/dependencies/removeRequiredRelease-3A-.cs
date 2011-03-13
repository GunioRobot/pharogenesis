removeRequiredRelease: aRelease
	"Remove <aRelease> as a required release."
	
	requiredReleases := requiredReleases copyWithout: aRelease.
	^ aRelease