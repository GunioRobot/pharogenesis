new   "Wonderland new" 
	"Create and initialize a new Wonderland."
	B3DPrimitiveEngine isAvailable ifFalse: [
	(self confirm: 'WARNING: This Squeak does not have real 3D support.
Opening a Wonderland will EXTREMELY time consuming.
Are you sure you want to do this?
(NO is probably the right answer :-)') ifFalse: [^ self]].
	Display depth < 8 ifTrue:
		[(self confirm: 'The display depth should be set to at least 8 bit.
Shall I do this now for you?') ifTrue: [Display newDepth: 8]].
	^ self basicNew initialize
