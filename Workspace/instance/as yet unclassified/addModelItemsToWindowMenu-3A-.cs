addModelItemsToWindowMenu: aMenu
	aMenu addLine.
	aMenu add: 'save contents to file...' target: self action: #saveContentsInFile 