open
	"ChangeSorterPluggable new open"
	| topView |
	World ifNotNil: [^ self openAsMorph].
	Sensor leftShiftDown ifTrue: [^ self openAsMorph].   "testing"

	topView _ StandardSystemView new.
	topView model: self.
	myChangeSet ifNil: [self myChangeSet: Smalltalk changes]. 
	topView label: self labelString.
	topView borderWidth: 1; minimumSize: 360@360.
	self openView: topView offsetBy: 0@0.
	topView controller open.
