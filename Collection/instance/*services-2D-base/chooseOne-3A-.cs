chooseOne: caption 
	"pops up a menu asking for one of the elements in the collection.
	If none is chosen, raises a ServiceCancelled notification"

	| m |
	m := MenuMorph entitled: caption.
	self do: 
			[:ea | 
			m 
				add: ea
				target: [:n | ^ n]
				selector: #value:
				argument: ea].
	m invokeModal.
	ServiceCancelled signal