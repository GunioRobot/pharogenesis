accounts
	"Lazily maintain a cache of all known account objects."

	accounts ifNotNil: [^accounts].
	accounts := objects select: [:o | o isAccount].
	^accounts