copy
	"Must copy the associations, or later store will effect both the
original and the copy"

	^ self shallowCopy withArray:
		(array collect: [:assoc |
			assoc ifNil: [nil]
				ifNotNil: [Association key: assoc key
value: assoc value]])