updateColor: aMorph color: aColor intensity: anInteger 
	"update the apareance of aMorph"
	| fill fromColor toColor |
	Preferences gradientMenu
		ifFalse: [^ self].
	fromColor := aColor.
	toColor := aColor.
	anInteger
		timesRepeat: [
			fromColor := fromColor lighter.
			toColor := toColor darker].
	fill := GradientFillStyle ramp: {0.0 -> fromColor. 1 -> toColor}.
	fill origin: aMorph topLeft.
	fill direction: aMorph width @ 0.
	fill radial: true.
	aMorph fillStyle: fill