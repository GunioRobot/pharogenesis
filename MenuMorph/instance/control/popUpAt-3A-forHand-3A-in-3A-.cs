popUpAt: aPoint forHand: hand in: aWorld
	"Present this menu at the given point under control of the given hand."
	self items isEmpty ifTrue: [^ self].
	self positionAt: aPoint relativeTo: (selectedItem ifNil:[self items first]) inWorld: aWorld.
	aWorld addMorphFront: self; startSteppingSubmorphsOf: self.
	"Aquire focus for valid pop up behavior"
	hand newMouseFocus: self.
	self changed