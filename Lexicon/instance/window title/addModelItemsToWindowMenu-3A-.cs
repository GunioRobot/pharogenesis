addModelItemsToWindowMenu: aMenu
	"Add model-related item to the window menu"

	super addModelItemsToWindowMenu: aMenu. 
	aMenu add: 'choose vocabulary...' target: self action: #chooseVocabulary