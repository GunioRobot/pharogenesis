suspendAcceleration
	"Temporarily suspend acceleration"
	myRenderer ifNotNil:[myRenderer destroy].
	myRenderer _ nil.
	self accelerationSuspended: true.
	self changed.