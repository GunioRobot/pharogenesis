lookupCachedResource: urlString in: candidates ifPresentDo: streamBlock
	"See if we have cached the resource described by the given url and if so, evaluate streamBlock with the cached resource."
	| sortedCandidates dir file |
	(candidates isNil or:[candidates size = 0])
		ifTrue:[^false].
	"First, try non-zip members (faster since no decompression is involved)"
	sortedCandidates _ (candidates reject:[:each| each beginsWith: 'zip://']),
					(candidates select:[:each| each beginsWith: 'zip://']).
	dir _ Project squeakletDirectory.
	sortedCandidates do:[:fileName|
		file _ self loadResource: urlString fromCacheFileNamed: fileName in: dir.
		file ifNotNil:[
			[streamBlock value: file] ensure:[file close].
			^true]].
	^false