delete

	| anInstance |
	arrays _ nil.
	exampler _ nil.
	self class removeFromSystem: false.
	anInstance := UnscriptedPlayer new.
	self become: anInstance.
