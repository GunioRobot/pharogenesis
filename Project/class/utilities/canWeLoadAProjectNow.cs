canWeLoadAProjectNow

	Smalltalk verifyMorphicAvailability ifFalse: [^ false].

	"starting to see about eliminating the below"
	"Smalltalk isMorphic ifFalse: [
		self inform: 'Later, allow jumping from MVC to Morphic Projects.'.
		^false
	]."

	^true
