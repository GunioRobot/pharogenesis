associationAtOrAbove: key ifAbsent: absentBlock
	"Look up an association with this key here or in an outer environment."

	^ super associationAt: key ifAbsent:
		[outerEnvt ifNil: [^ absentBlock value].
		^ outerEnvt associationAtOrAbove: key ifAbsent: absentBlock]