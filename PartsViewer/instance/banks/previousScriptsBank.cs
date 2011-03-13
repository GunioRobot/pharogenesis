previousScriptsBank
	scriptsBank _ self scriptsBank - 1.
	scriptsBank < 1 ifTrue: [scriptsBank _ self maxScriptsBankNumber].
	self presenter updatePartsViewer: self