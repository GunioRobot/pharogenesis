isActive
	"Answer active if no owner too to avoid color flickering."
	
	self owner ifNil: [^true].
	self activeOnlyOnTop ifTrue: [^ self == TopWindow].
	^ true