buildMorphicCodePaneWith: editString

	| codePane |

	codePane _ PluggableTextMorph 
		on: self 
		text: #contents 
		accept: #contents:notifying:
		readSelection: #contentsSelection 
		menu: #codePaneMenu:shifted:.
	editString ifNotNil: [
		codePane editString: editString.
		codePane hasUnacceptedEdits: true
	].
	^codePane
