asKnownNameMenu
	"Return a menu to select an element of the collection.  
	Menu uses the knownName or class name as only description of  
	element."
	| menu |
	menu := CustomMenu new.
	self
		do: [:m | menu
				add: (m knownName
						ifNil: [m class name asString])
				action: m].
	^ menu