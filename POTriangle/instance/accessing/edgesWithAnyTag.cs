edgesWithAnyTag
	^ self edges select: [:edge | edge tags isEmptyOrNil not]