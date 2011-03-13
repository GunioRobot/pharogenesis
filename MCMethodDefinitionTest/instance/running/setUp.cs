setUp
	navigation := (Smalltalk hasClassNamed: #SystemNavigation)
		ifTrue: [(Smalltalk at: #SystemNavigation) new]
		ifFalse: [Smalltalk].
	isModified := self ownPackage modified.