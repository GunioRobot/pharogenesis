users
	"Lazily maintain a cache of all known account objects
	keyed by their developer initials."

	users ifNotNil: [^users].
	users := Dictionary new.
	self accounts do: [:a | users at: a initials put: a].
	^users