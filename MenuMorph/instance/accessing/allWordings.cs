allWordings
	| verboten |
	"Answer a collection of the wordings of all items and subitems, omitting debug menu"
	verboten _ Preferences debugMenuItemsInvokableFromScripts 
		ifTrue:	[nil]
		ifFalse:	['debug...'].
	^ self allWordingsNotInSubMenu: verboten