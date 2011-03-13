delete

	| anInstance |
	turtles delete.
	sequentialStub delete.

	self class removeFromSystem: false.

	anInstance _ UnscriptedPlayer new.
	self become: anInstance.
