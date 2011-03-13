testDoItEvent1

	self systemChangeNotifier notify: self
		ofAllSystemChangesUsing: #methodDoItEvent1:.
	doItExpression := '1 + 2'.
	Compiler evaluate: doItExpression logged: true.
	self checkForOnlySingleEvent