addModelItemsToWindowMenu: aMenu
	"Add model-related items to the supplied window menu"

	aMenu addLine.
	aMenu add: 'save contents to file...' target: self action: #saveContentsInFile.
	aMenu add: 'append contents of file...' target: self action: #appendContentsOfFile.
	aMenu addLine.
	aMenu 
		addUpdating: #acceptDroppedMorphsWording
		target: self
		action: #toggleDroppingMorphForReference