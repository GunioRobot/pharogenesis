preferenceValue: aValue
	"set the value as indicated, and invoke the change selector if appropriate"

	| oldValue |
	oldValue _ value.
	value _ aValue.
	oldValue ~~ value ifTrue:
		[self notifyInformeeOfChange]