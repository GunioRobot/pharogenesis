noteField: field 
	"note that the receiver has the specified text field"
	fields ifNil: [fields := OrderedCollection new].
	fields add: field