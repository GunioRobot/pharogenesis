fullStack
	"Change from displaying the minimal stack to a full one."

	model contextStackList size > 7
		ifTrue:
			[view flash]
		ifFalse:
			[model contextStackIndex = 0
				ifFalse: [model toggleContextStackIndex: model contextStackIndex].
			self controlTerminate.
			model fullyExpandStack.
			self controlInitialize]