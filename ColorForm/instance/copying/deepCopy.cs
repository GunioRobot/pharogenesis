deepCopy

	^ self shallowCopy
		bits: bits copy;
		offset: offset copy;
		colors: colors
