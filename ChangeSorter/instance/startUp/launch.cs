launch
	"recompute what to show in all panes"
	| cls msg |
	buttonView label: myChangeSet name asParagraph.  "in case it changed"
	buttonView display.
	cls _ classList selection.		"save current selection"
	msg _ messageList selection.
	Cursor wait showWhile: [
		classList list: (myChangeSet changedClasses collect: 
				[:each | each printString]) asOrderedCollection].
	classList selection: cls.		"try to reselect old selection, if there"
	messageList selection: msg.
	self setContents.