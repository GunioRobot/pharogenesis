removeEnvelope: anEnvelope
	"Remove the given envelope from my envelopes list."

	envelopes _ envelopes copyWithout: anEnvelope.
