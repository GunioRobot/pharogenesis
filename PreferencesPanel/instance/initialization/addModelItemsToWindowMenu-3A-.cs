addModelItemsToWindowMenu: aMenu
	"aMenu is being constructed to be presented to the user in response to the user's pressing on the menu widget in the title bar of a morphic SystemWindow.  Here, the model is given the opportunity to add any model-specific items to the menu, whose default target is the SystemWindow itself."

	true ifTrue: [^ self].  

	"The below are provisionally disenfranchised, because their function is now directly available in the ? category"
	aMenu addLine.
	aMenu add: 'find preference... (f)' target: self action: #findPreference:.
	aMenu add: 'inspect parameters' target: Preferences action: #inspectParameters