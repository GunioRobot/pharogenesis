mouseLeaveDragging: evt
	"lock children after drop operations"
	(self ~~ TopWindow and:[evt hand hasSubmorphs]) ifTrue:[
		self lockInactivePortions.
		evt hand removeMouseListener: self.
	].