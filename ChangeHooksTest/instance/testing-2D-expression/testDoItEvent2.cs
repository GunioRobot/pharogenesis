testDoItEvent2

	self systemChangeNotifier notify: self
		ofAllSystemChangesUsing: #shouldNotBeCalledEvent:.
	doItExpression := '1 + 2'.
	Compiler evaluate: doItExpression logged: false.