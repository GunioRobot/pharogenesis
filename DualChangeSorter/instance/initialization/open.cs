open
	| topView |
	Smalltalk isMorphic | Sensor leftShiftDown ifTrue: [^ self openAsMorph].

	leftCngSorter _ ChangeSorter new myChangeSet: ChangeSet current.
	leftCngSorter parent: self.
	rightCngSorter _ ChangeSorter new myChangeSet: 
			ChangeSorter secondaryChangeSet.
	rightCngSorter parent: self.

	topView _ (StandardSystemView new) model: self; borderWidth: 1.
	topView label: leftCngSorter label.
	topView minimumSize: 300 @ 200.
	leftCngSorter openView: topView offsetBy: 0@0.
	rightCngSorter openView: topView offsetBy: 360@0.
	topView controller open.
