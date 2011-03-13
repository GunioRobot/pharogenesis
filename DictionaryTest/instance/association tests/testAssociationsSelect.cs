testAssociationsSelect
	| answer d |
	d := Dictionary new.
	d at: (Array with: #hello with: #world)
	  put: #fooBar.
	d at: Smalltalk put: #'Smalltalk is the key'.
	d at: #Smalltalk put: Smalltalk.
	answer := d
				associationsSelect: [:assoc | assoc key == #Smalltalk
						and: [assoc value == Smalltalk]].
	self
		should: [answer isKindOf: Dictionary].
	self
		should: [answer size == 1].
	self
		should: [(answer at: #Smalltalk)
				== Smalltalk].
	answer := d
				associationsSelect: [:assoc | assoc key == #NoSuchKey
						and: [assoc value == #NoSuchValue]].
	self
		should: [answer isKindOf: Dictionary].
	self
		should: [answer size == 0]