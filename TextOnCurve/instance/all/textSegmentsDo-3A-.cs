textSegmentsDo: blockForLineDestPivotAngle
	| segments segSpec |
	(segments _ container textSegments) ifNil: [^ self].
	1 to: lines size do:
		[:i | segSpec _ segments at: i.
		blockForLineDestPivotAngle
			value: (lines at: i)
			value: (segSpec at: 1)
			value: (segSpec at: 2)
			value: (segSpec at: 3)]
