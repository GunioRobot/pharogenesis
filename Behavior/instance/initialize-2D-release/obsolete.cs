obsolete
	"Invalidate and recycle local messages,
	e.g., zap the method dictionary if can be done safely."
	self canZapMethodDictionary
		ifTrue:[ methodDict _ self emptyMethodDictionary ].