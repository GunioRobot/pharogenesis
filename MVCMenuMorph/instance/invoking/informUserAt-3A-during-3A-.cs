informUserAt: aPoint during: aBlock
	"Add this menu to the Morphic world during the execution of the given block."

	| title |
	Smalltalk isMorphic ifFalse: [^ self].

	title _ submorphs first submorphs first.
	self visible: false.
	aBlock value:[:string|
		self visible ifFalse:[
			World addMorph: self centeredNear: aPoint.
			self visible: true].
		title contents: string.
		self setConstrainedPositionFrom: Sensor cursorPoint.
		self changed.
		World displayWorld].  "show myself"
	self delete.
	World displayWorld