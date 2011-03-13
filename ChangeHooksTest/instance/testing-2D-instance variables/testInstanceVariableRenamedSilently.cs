testInstanceVariableRenamedSilently

	self systemChangeNotifier notify: self
		ofAllSystemChangesUsing: #shouldNotBeCalledEvent:.
	generatedTestClassX renameSilentlyInstVar: 'x' to: 'y'