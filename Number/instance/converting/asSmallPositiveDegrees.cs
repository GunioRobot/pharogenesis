asSmallPositiveDegrees
	"Return the receiver normalized to lie within the range (0, 360)"

	| result |
	result _ self.
	[result < 0] whileTrue: [result _ result + 360].
	^ result \\ 360

"#(-500 -300 -150 -5 0 5 150 300 500 1200) collect: [:n | n asSmallPositiveDegrees]"