asBezierShape
	"Demote a cubic bezier to a set of approximating quadratic beziers.
	Should convert to forward differencing someday"

	| curves pts step prev index a b f |
	curves _ self bezier2SegmentCount: 0.5.
	pts _ PointArray new: curves * 3.
	step _ 1.0 / (curves * 2).
	prev _ start.
	1 to: curves do: [ :c |
		index _ 3*c.
		a _ pts at: index-2 put: prev.
		b _ (self valueAt: (c*2-1)*step).
		f _ pts at: index put: (self valueAt: (c*2)*step).
		pts at: index-1 put: (4 * b - a - f) / 2.
		prev _ pts at: index.
		].
	^ pts.
	