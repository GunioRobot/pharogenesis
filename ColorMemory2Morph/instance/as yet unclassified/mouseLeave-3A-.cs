mouseLeave: evt

	owner invalidRect: owner colorPatch bounds.	"show last truly chosen color"
	self delete.	"stop showing me"