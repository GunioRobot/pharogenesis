removeAllControllersSatisfying: aBlock
	"Unschedule and delete all controllers satisfying aBlock.  May not leave the screen exactly right sometimes. "

	(self controllersSatisfying:  aBlock) do:
		[:aController | aController closeAndUnschedule]