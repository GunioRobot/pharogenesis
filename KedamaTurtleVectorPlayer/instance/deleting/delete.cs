delete

	| anInstance |
	exampler _ nil.
	arrays _ nil.
	whoTable _ nil.
	turtlesMap _ nil.
	self class removeFromSystem: false.
	anInstance := UnscriptedPlayer new.
	self become: anInstance.
