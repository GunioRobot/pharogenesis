copyEnvelopes
	"Private! Support for copying. Copy my envelopes."

	envelopes _ envelopes collect: [:e | e copy target: self].
