computeAltFramedColors
	| base light dark w hw colorArray param |
	base _ self color asColor.
	light _ Color white.
	dark _ Color black.
	w _ self width isPoint ifTrue:[self width x max: self width y] ifFalse:[self width].
	w _ w asInteger.
	w = 1 ifTrue:[^{base mixed: 0.5 with: light. base mixed: 0.5 with: dark}].
	colorArray _ Array new: w.
	hw _ w // 2.
	"brighten"
	0 to: hw-1 do:[:i|
		param _ 0.5 + (i asFloat / hw * 0.5).
		colorArray at: i+1 put: (base mixed: param with: dark). "brighten"
		colorArray at: w-i put: (base mixed: param with: light). "darken"
	].
	w odd ifTrue:[colorArray at: hw+1 put: base].
	^colorArray, colorArray