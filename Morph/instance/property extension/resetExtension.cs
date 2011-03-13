resetExtension
	"Reset the extension slot if it is not needed"
	extension ifNil:[^false]. "not removed"
	extension isDefault ifTrue:[
		extension _ nil.
		^true].
	^false