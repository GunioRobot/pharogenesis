invokeOn: targetObject 
	"Pop up this menu and return the result of sending
	to the target object the selector corresponding to 
	the menu item selected by the user. Return 
	nil if no item is selected.
	Example:
	((SelectionMenu 
	      labels: 'sin\cos\neg' withCRs
	      lines: #() 
	      selections: #(sin cos negated)) invokeOn: 0.7)	
	"
	^ self startUp
		ifNotNil: [:sel | targetObject perform: sel]