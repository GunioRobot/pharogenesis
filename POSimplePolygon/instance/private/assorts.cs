assorts
	"Builds a SortedCollection of my vertices. The sort order is       
	lexicographically.     
	This can be used as an eventqueue for sweepline algorithms."
	assorts
		ifNil: 
			[assorts _ SortedCollection
						sortBlock: [:a :b | a x < b x
								or: [a x = b x and: [a y < b y]]].
			assorts addAll: self vertices].
	^ assorts