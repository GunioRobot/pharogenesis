edgesWithoutAnyTag
	^ self edges select: [:edge | edge tags isEmptyOrNil]