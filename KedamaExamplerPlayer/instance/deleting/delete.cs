delete

	| anInstance |
	turtles delete.
	sequentialStub delete.

	self class removeFromSystem: false.

	anInstance := UnscriptedPlayer new.
	self become: anInstance.
