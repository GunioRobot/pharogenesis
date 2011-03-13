adoptMessageInCurrentChangeset
	"Add the receiver's method to the current change set if not already there"

	self setClassAndSelectorIn: [:cl :sel |
		cl ifNotNil:
			[Smalltalk changes adoptSelector: sel forClass: cl.
			self changed: #annotation]]
