open
	"ChangeSorterPluggable new open"
	| topView |
	Smalltalk isMorphic | Sensor leftShiftDown ifTrue: [^ self openAsMorph].

	topView := StandardSystemView new.
	topView model: self.
	myChangeSet ifNil: [self myChangeSet: ChangeSet current]. 
	topView label: self labelString.
	topView borderWidth: 1; minimumSize: 360@360.
	self openView: topView offsetBy: 0@0.
	topView controller open.
