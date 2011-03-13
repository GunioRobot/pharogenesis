updateMenu: aMenu forModel: aModel selector: selector
	('codePane*' match: selector) ifTrue: [
	(self new for: aModel id: #codeSelectionRefactorings) inlineInMenu: aMenu].
	^ aMenu
	