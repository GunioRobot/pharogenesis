accounts
	"Lazily maintain a cache of all known account objects."

	accounts ifNotNil: [^accounts].
	accounts _ objects select: [:o | o isAccount].
	^accounts