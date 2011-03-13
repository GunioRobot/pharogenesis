buildMorphicCodePaneWith: editString

	| codePane |

	codePane _ AcceptableCleanTextMorph
		on: self
		text: #contents 
		accept: #contents:
		readSelection: #contentsSelection 
		menu: #codePaneMenu:shifted:.
	editString ifNotNil: [
		codePane editString: editString.
		codePane hasUnacceptedEdits: true
	].
	^codePane
