releaseImage: command
	| cacheID |

	CachedForms ifNil: [^self].
	cacheID _ self class decodeInteger: (command at: 2).
	CachedForms at: cacheID put: nil.
