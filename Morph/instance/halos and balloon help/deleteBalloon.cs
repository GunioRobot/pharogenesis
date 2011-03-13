deleteBalloon
	"If I am showing a balloon, delete it."

	| balloon |
	(balloon _ self valueOfProperty: #balloon) ifNil: [^ self].
	balloon delete.
	self setProperty: #balloon toValue: nil.
