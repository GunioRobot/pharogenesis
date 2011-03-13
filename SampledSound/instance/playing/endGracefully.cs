endGracefully
	"See stopGracefully, which affects initialCOunt, and I don't think it should (di)."

	| decayInMs env |
	envelopes isEmpty
		ifTrue: [
			self adjustVolumeTo: 0 overMSecs: 10.
			decayInMs _ 10]
		ifFalse: [
			env _ envelopes first.
			decayInMs _ env attackTime + env decayTime].
	count _ decayInMs * self samplingRate // 1000.
