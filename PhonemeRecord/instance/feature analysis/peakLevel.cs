peakLevel
	"Answer the absolute value of the peak sample value my buffer."

	| maxVal v |
	maxVal := 0.
	1 to: samples size do: [:i |
		v := samples at: i.
		v < 0 ifTrue: [v := 0 - v].
		v > maxVal ifTrue: [maxVal := v]].
	^ maxVal
