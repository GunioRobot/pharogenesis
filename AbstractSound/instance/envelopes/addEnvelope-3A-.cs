addEnvelope: anEnvelope
	"Add the given envelope to my envelopes list."

	anEnvelope target: self.
	envelopes _ envelopes copyWith: anEnvelope.
