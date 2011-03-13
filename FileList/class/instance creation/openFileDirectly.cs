openFileDirectly

	| aResult |
	(aResult := StandardFileMenu oldFile) ifNotNil:
		[self openEditorOn: (aResult directory readOnlyFileNamed: aResult name) editString: nil]