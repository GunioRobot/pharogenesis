setPitch: pitchNameOrNumber dur: d loudness: l
	"Select a modulation ratio and modulation envelope scale based on my pitch."

	| p modScale |
	p _ self nameOrNumberToPitch: pitchNameOrNumber.
	modScale _ 9.4.
	p > 100.0 ifTrue: [modScale _ 8.3].
	p > 150.0 ifTrue: [modScale _ 6.4].
	p > 200.0 ifTrue: [modScale _ 5.2].
	p > 300.0 ifTrue: [modScale _ 3.9].
	p > 400.0 ifTrue: [modScale _ 2.8].
	p > 600.0 ifTrue: [modScale _ 1.7].

	envelopes size > 0 ifTrue: [
		envelopes do: [:e |
			(e updateSelector = #modulation:)
				ifTrue: [e scale: modScale]]].

	super setPitch: p dur: d loudness: l.
