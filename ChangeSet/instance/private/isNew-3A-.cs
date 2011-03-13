isNew: class
	"Answer whether this class was added since the ChangeSet was cleared."

	(class isKindOf: Metaclass)
		ifTrue: [^self atClass: class soleInstance includes: #add "check class"]
		ifFalse: [^self atClass: class includes: #add]