cacheVal
	| icHit mcHit mcMiss total deltaMcMiss deltaMcHit deltaIcHit |
	mcMiss _ vmParameters at: 15.
	deltaMcMiss _ mcMiss - prevMcMiss.
	prevMcMiss _ mcMiss.
	mcHit _ vmParameters at: 16.
	deltaMcHit _ mcHit - prevMcHit.
	prevMcHit _ mcHit.
	icHit _ vmParameters at: 17.
	deltaIcHit _ icHit - prevIcHit.
	prevIcHit _ icHit.
	total _ deltaMcMiss + deltaMcHit + deltaIcHit.
	total = 0 ifTrue: [total _ 1].
	deltaMcMiss _ (deltaMcMiss * 100 / total asInteger).
	deltaMcHit _ (deltaMcHit * 100 / total asInteger).
	^Array
		with: deltaMcMiss
		with: deltaMcMiss + deltaMcHit