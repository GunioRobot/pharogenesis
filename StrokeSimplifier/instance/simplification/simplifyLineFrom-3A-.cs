simplifyLineFrom: p5
	"Remove a point if it represents the intermediate point of a line.
	We only remove 'inner' points of a line, that is, for a sequence of points like

	p1----p2----p3----p4---p5

	we will remove only p3. This is so that any curve can be adequately represented, e.g., so that for a stroke running like:

		p0
		 |
		p1----p2----p3----p4----p5
							   |
							   |
							  p6
	we will neither touch p2 (required for the curve p0,p1,p2) nor p5 yet (the shape of the curve relies on p6 which is not yet recorded."
	| p4 p3 p2 p1 d1 d2 d3 d4 cosValue |
	p4 _ p5 prevPoint ifNil:[^self].
	"Note: p4 (actually p1 from above) is final after we know the next point."
	p3 _ p4 prevPoint ifNil:[^p4 isFinal: true].
	p2 _ p3 prevPoint ifNil:[^self].
	p1 _ p2 prevPoint ifNil:[^self].
	"First, compute the change in direction at p3 (this is the point we are *really* interested in)."
	d2 _ p2 forwardDirection.
	d3 _ p3 forwardDirection.
	cosValue _ d2 dotProduct: d3.

	"See if the change is below the threshold for linearity.
	Note that the above computes the cosine of the directional change
	at p2,p3,p4 so that a value of 1.0 means no change at all, and -1.0
	means a reversal of 180 degrees."
	cosValue < 0.99 ifTrue:[
		"0.999 arcCos radiansToDegrees is approx. 2.56 degrees.
		If the cosine is less than we consider this line to be curved."
		^p2 isFinal: true]. "we're done here"

	"Okay, so the line is straight. Now make sure that the previous and the
	next segment are straight as well (so that we don't remove a point which
	defines the start/end of a curved segment)"

	d1 _ p1 forwardDirection.
	cosValue _ d1 dotProduct: d2.
	cosValue < 0.95 ifTrue:[
		"0.99 arcCos radiansToDegrees is approx. 8 degrees"
		^p2 isFinal: true].

	"And the same for the last segment"
	d4 _ p4 forwardDirection.
	cosValue _ d3 dotProduct: d4.
	cosValue < 0.95 ifTrue:[
		"0.99 arcCos radiansToDegrees is approx. 8 degrees"
		^p2 isFinal: true].

	"Okay, so p3 defines an inner point of a pretty straight line.
	Let's get rid of it."
	p2 nextPoint: p4.
	p4 prevPoint: p2.
	p2 releaseCachedState.
	p3 releaseCachedState.
	p4 releaseCachedState.