simplifyIncrementally
	"Simplify the last point that was added"
	| prevPt dir |
	lastStrokePoint ifNil:[^self addFirstPoint].
	prevPt _ (points at: points size-1).
	dir _ lastPoint position - prevPt position.
	distance _ distance + (dir dotProduct: dir). "e.g., distance^2"
	samples _ samples + 1.
	"time _ time + (points last key - (points at: points size-1) key)."
	"If we have sampled too many points or went too far,
	add the next point. This may eventually result in removing earlier points."
	(samples >= maxSamples or:[distance >= maxDistance "or:[time > maxTime]"]) 
		ifTrue:[^self addNextPoint].
	"Note: We may want to add a time/speed feature in the future."