initializeTranslucentPatterns
	"Color initializeTranslucentPatterns"
	| mask bits pattern patternList |
	TranslucentPatterns _ Array new: 8.
	#(1 2 4 8) do:[:d|
		patternList _ Array new: 5.
		mask _ (1 bitShift: d) - 1.
		bits _ 2 * d.
		[bits >= 32] whileFalse: [
			mask _ mask bitOr: (mask bitShift: bits).  "double the length of mask"
			bits _ bits + bits].
		"0% pattern"
		pattern _ Bitmap with: 0 with: 0.
		patternList at: 1 put: pattern.
		"25% pattern"
		pattern _ Bitmap with: mask with: 0.
		patternList at: 2 put: pattern.
		"50% pattern"
		pattern _ Bitmap with: mask with: mask bitInvert32.
		patternList at: 3 put: pattern.
		"75% pattern"
		pattern _ Bitmap with: mask with: 16rFFFFFFFF.
		patternList at: 4 put: pattern.
		"100% pattern"
		pattern _ Bitmap with: 16rFFFFFFFF with: 16rFFFFFFFF.
		patternList at: 5 put: pattern.
		TranslucentPatterns at: d put: patternList.
	].