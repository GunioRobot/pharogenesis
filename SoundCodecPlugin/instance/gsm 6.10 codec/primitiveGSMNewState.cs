primitiveGSMNewState

	| stateBytes state |
	self export: true.
	stateBytes _ self cCode: 'gsmStateBytes()'.
	state _ interpreterProxy
		instantiateClass: interpreterProxy classByteArray
		indexableSize: stateBytes.
	self cCode: 'gsmInitState(state + 4)'.
	interpreterProxy push: state.
