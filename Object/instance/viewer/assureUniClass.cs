assureUniClass
	"If the receiver is not yet an instance of a uniclass, create a uniclass for it and make the receiver become an instance of that class."

	| anInstance |
	self belongsToUniClass ifTrue: [^ self].
	anInstance _ self class instanceOfUniqueClass.
	self become: (self as: anInstance class).
	^ anInstance