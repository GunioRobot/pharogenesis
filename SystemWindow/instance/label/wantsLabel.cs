wantsLabel
	"Answer whether the receiver wants a label.  At the moment, the only way to suppress this at initialization is to call SystemWindow newWithoutLabel"

	^ (self hasProperty: #suppressLabel) not