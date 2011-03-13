testInstanceVariableCreationEvent2

	self systemChangeNotifier notify: self
		ofAllSystemChangesUsing: #instanceVariableCreationEvent:.
	generatedTestClass addInstVarName: 'x'.
	self checkForOnlySingleEvent