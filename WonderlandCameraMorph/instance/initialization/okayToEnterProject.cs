okayToEnterProject
	"Check if it is okay to enter the project containing the receiver"
	B3DPrimitiveEngine isAvailable ifFalse:[
		^(self confirm:'You are about to enter a project requiring 3D primitive support.
This support is currently NOT available.
Do you really want to enter the project?')].
	^true