delete

	| anInstance |
	arrays := nil.
	exampler := nil.
	self class removeFromSystem: false.
	anInstance := UnscriptedPlayer new.
	self become: anInstance.
