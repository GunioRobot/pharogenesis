assureUniClass
	| anInstance |
	anInstance _ Player instanceOfUniqueClass.
	anInstance initializeCostumesFrom: self.
	self become: anInstance.
	^ anInstance