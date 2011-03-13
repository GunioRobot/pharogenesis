reconstituteList
	"Reformulate the list.  Here, since we have a manually-maintained list, at this juncture we only make sure change-set-names are still up to date, and we purge moribund elements"

	|  survivors |
	survivors := elementDictionary select: [:aChangeSet | aChangeSet isMoribund not].
	self clear.
	(survivors asSortedCollection: [:a :b | a name <= b name]) reverseDo:
		[:aChangeSet | self addChangeSet: aChangeSet]