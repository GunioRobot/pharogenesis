testInstanceVariableRemovedEvent2

	self systemChangeNotifier notify: self
		ofAllSystemChangesUsing: #instanceVariableRemovedEvent:.
	generatedTestClassX removeInstVarName: 'x'.
	self checkForOnlySingleEvent