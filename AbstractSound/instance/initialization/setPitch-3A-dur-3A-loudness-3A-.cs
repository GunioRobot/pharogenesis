setPitch: p dur: d loudness: l
	"Initialize my envelopes for the given parameters. Subclasses overriding this method should include a resend to super."

	envelopes do: [:e |
		(e isKindOf: VolumeEnvelope) ifTrue: [e scale: l].
		(e isKindOf: PitchEnvelope) ifTrue: [e centerPitch: p].
		e duration: d].
	self initialVolume: l.
	self duration: d.

