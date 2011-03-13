mouseLeaveDragging: evt
	"lock children after drop operations"
	(self ~~ TopWindow and:[evt hand hasSubmorphs]) ifTrue:[
		self submorphsDo:[:m| m lock].
		evt hand removeMouseListener: self.
	].