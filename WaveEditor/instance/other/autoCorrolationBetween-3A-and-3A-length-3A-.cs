autoCorrolationBetween: index1 and: index2 length: length
	"Answer the cummulative error between the portions of my waveform starting at the given two indices and extending for the given length. The larger this error, the greater the difference between the two waveforms."

	| data error i1 e |
	data _ graph data.
	error _ 0.
	i1 _ index1.
	index2 to: (index2 + length - 1) do: [:i2 |
		e _ (data at: i1) - (data at: i2).
		e < 0 ifTrue: [e _ 0 - e].
		error _ error + e.
		i1 _ i1 + 1].
	^ error
