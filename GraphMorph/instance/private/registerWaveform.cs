registerWaveform
	"Store my data as the default sample table for SampledSound."

	SampledSound defaultSampleTable: (data collect: [:x | x asInteger]).
	SampledSound nominalSamplePitch: 153.
