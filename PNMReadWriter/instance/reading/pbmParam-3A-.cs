pbmParam: line
	"Look for a parameter hidden in a comment"
	| key tokens |
	tokens _ line findTokens: ' '.
	key _ (tokens at: 1) asLowercase.
	(key = '#origin' and:[tokens size = 3]) ifTrue:[	"ORIGIN key word"
		"This is for SE files as described in:
		Algoritms For Image Processing And Computer Vision. J. R. Parker"
		origin _ ((tokens at: 2) asInteger) @ ((tokens at: 3) asInteger)
	].
