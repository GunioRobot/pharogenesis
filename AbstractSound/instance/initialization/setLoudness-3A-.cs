setLoudness: vol
	"Initialize my volume envelopes and initial volume. Subclasses overriding this method should include a resend to super."

	envelopes do: [:e |
		(e isKindOf: VolumeEnvelope) ifTrue: [e scale: vol]].
	self initialVolume: vol.
