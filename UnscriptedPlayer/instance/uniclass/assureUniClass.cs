assureUniClass
	"Create a uniclass and become the receiver into it"

	| anInstance |
	anInstance _ self rootClassForUniclasses instanceOfUniqueClass.
	anInstance initializeCostumesFrom: self.
	self become: anInstance.
	^ anInstance