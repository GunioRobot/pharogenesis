defineMatrixFlags: dict
	"Define the flags for analyzing vertices"
	"B3DPoolDefiner initPool"
	self initFromSpecArray:
	#(
		(FlagM44Identity 1)		"Matrix is identity"
		(FlagM44NoPerspective 2) "Matrix has no perspective part"
		(FlagM44NoTranslation 4) "Matrix has no translation"
	) in: dict