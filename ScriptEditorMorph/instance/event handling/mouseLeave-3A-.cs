mouseLeave: evt
	owner ifNil: [^ self].	"left by being removed, not by mouse movement"
	(self hasProperty: #justPickedUpPhrase) ifTrue:[
		self removeProperty: #justPickedUpPhrase.
		^self].
	self stopSteppingSelector: #trackDropZones.
	handWithTile _ nil.
	self removeSpaces.