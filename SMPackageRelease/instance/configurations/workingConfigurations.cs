workingConfigurations
	"Return all working configurations."
	
	^ self configurations select: [:c | c isWorking ]