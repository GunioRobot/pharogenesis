atOrAbove: key ifAbsent: absentBlock
	"Look up the value iof this key here or in an outer environment."

	^ super at: key ifAbsent:
		[outerEnvt ifNil: [^ absentBlock value].
		^ outerEnvt atOrAbove: key ifAbsent: absentBlock]