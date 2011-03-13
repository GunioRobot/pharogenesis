fullStack
	"Change from displaying the minimal stack to a full one."

	self contextStackList size > 20 "Already expanded"
		ifTrue:
			[self changed: #flash]
		ifFalse:
			[self contextStackIndex = 0 ifFalse: [
				self toggleContextStackIndex: self contextStackIndex].
			self fullyExpandStack]