categories
	"Lazily maintain a cache of all known category objects."

	categories ifNotNil: [^categories].
	categories _ objects select: [:o | o isCategory].
	^categories