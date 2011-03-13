informUserAt: aPoint during: aBlock
	"Add this menu to the Morphic world during the execution of the given block."

	| title w |
	Smalltalk isMorphic ifFalse: [^ self].

	title _ submorphs first submorphs first.
	self visible: false.
	w _ Display getCurrentMorphicWorld.
	aBlock value:[:string|
		self visible ifFalse:[
			w addMorph: self centeredNear: aPoint.
			self visible: true].
		title contents: string.
		self setConstrainedPositionFrom: Sensor cursorPoint.
		self changed.
		w displayWorld		 "show myself"
	]. 
	self delete.
	w displayWorld