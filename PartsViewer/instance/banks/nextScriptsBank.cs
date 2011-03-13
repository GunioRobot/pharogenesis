nextScriptsBank
	scriptsBank _ self scriptsBank + 1.
	scriptsBank > self maxScriptsBankNumber ifTrue: [scriptsBank _ 1].
	self presenter updatePartsViewer: self