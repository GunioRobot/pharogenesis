morphicWindow
	
	| window |
	leftCngSorter _ ChangeSorter new myChangeSet: ChangeSet current.
	leftCngSorter parent: self.
	rightCngSorter _ ChangeSorter new myChangeSet: 
			ChangeSorter secondaryChangeSet.
	rightCngSorter parent: self.

	window _ (SystemWindow labelled: leftCngSorter label) model: self.
	"topView minimumSize: 300 @ 200."
	leftCngSorter openAsMorphIn: window rect: (0@0 extent: 0.5@1).
	rightCngSorter openAsMorphIn: window rect: (0.5@0 extent: 0.5@1).
	^ window
