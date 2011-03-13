testReversedComparisons
	"check that it is never the case that v1<v2 and v2<v1"

	typicalVersions do: [ :v1 |
		typicalVersions do: [ :v2 |
			self should: [ (v1 < v2) not  or:  [  (v2 < v1) not ] ] ] ].

	