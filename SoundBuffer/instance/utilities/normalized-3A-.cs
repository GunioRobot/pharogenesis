normalized: percentOfFullVolume
	"Increase my amplitudes so that the highest peak is the given percent of full volume. For example 's normalized: 50' would normalize to half of full volume."

	| peak s mult |
	peak _ 0.
	1 to: self size do: [:i |
		s _ (self at: i) abs.
		s > peak ifTrue: [peak _ s]].
	mult _ (32767.0 * percentOfFullVolume) / (100.0 * peak).
	1 to: self size do: [:i | self at: i put: (mult * (self at: i)) asInteger].
