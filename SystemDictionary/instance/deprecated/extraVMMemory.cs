extraVMMemory
	"Answer the current setting of the 'extraVMMemory' VM
	parameter. See the comment in extraVMMemory: for details."
	self deprecated: 'Use SmalltalkImage current extraVMMemory'.
	^ self vmParameterAt: 23