writesField: field 
	"Answer whether the receiver stores into the instance variable indexed 
	by the argument."

	self isQuick ifTrue: [^false].
	field <= 8 ifTrue: [^ (self scanFor: 96 + field - 1)
						or: [self scanLongStore: field - 1]].
	field <= 64 ifTrue: [^ self scanLongStore: field - 1].
	^ self scanVeryLongStore: 160 offset: field - 1