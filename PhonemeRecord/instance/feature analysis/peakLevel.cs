peakLevel
	"Answer the absolute value of the peak sample value my buffer."

	| maxVal v |
	maxVal _ 0.
	1 to: samples size do: [:i |
		v _ samples at: i.
		v < 0 ifTrue: [v _ 0 - v].
		v > maxVal ifTrue: [maxVal _ v]].
	^ maxVal
