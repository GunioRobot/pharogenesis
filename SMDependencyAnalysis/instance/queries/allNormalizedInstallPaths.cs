allNormalizedInstallPaths
	"Same as allInstallPaths, but with paths removed that
	are clear supersets of others."

	| installPaths |
	installPaths := self allInstallPaths.
	installPaths := installPaths reject: [:p1 |
					installPaths anySatisfy: [:p2 |
						(p1 ~~ p2) and: [p1 includesAllOf: p2]]].
	^installPaths