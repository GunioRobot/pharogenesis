createSequenceStub

	| class |
	class _ self class createSequencialStubSubclass.
	sequentialStub _ class new.
	sequentialStub kedamaWorld: kedamaWorld.
	sequentialStub examplerPlayer: self.
	sequentialStub turtles: turtles.
