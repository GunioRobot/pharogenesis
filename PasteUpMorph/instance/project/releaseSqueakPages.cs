releaseSqueakPages
	| uu |
	"If this world has a book with SqueakPages, then clear the SqueakPageCache"

	submorphs do: [:sub | (sub isKindOf: BookMorph) ifTrue: [
		uu _ sub valueOfProperty: #url ifAbsent: [nil].
		uu ifNotNil: [(SqueakPageCache pageCache includesKey: uu) ifTrue: [
				SqueakPageCache initialize]]]].	"wipe the cache"