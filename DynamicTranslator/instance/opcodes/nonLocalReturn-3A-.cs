nonLocalReturn: value
	"Return value to the sender of the method that created the active context.  For methods
	this is the sender, for blocks this is the sender of the home context."

	self inline: true.
	self sharedCodeNamed: 'commonNonLocalReturn' inCase: CommonNonLocalReturnCase.

	(self isCachedMethodContext: localCP) ifTrue: [
		self localReturn: value.
	] ifFalse: [
		self externalizeIPandSP.
		self nonLocalBlockReturn: value.
		self internalizeIPandSP.
	]