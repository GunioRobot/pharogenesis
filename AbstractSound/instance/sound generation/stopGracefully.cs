stopGracefully
	"End this note with a graceful decay. If the note has envelopes, determine the decay time from its envelopes."

	| decayInMs env |
	envelopes isEmpty
		ifTrue: [
			self adjustVolumeTo: 0 overMSecs: 10.
			decayInMs _ 10]
		ifFalse: [
			env _ envelopes first.
			decayInMs _ env attackTime + env decayTime].
	self duration: (mSecsSinceStart + decayInMs) / 1000.0.
	self stopAfterMSecs: decayInMs.
