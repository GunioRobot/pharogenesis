deleteBalloon
	"If I am showing a balloon, delete it."
	| w |
	w _ self world ifNil:[^self].
	w deleteBalloonTarget: self.