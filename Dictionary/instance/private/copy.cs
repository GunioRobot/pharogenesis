copy
	"Must copy the associations, or later store will affect both the
original and the copy"

	^ self shallowCopy withArray:
		(array collect: [:assoc |
			assoc ifNil: [nil]
				ifNotNil: [Association key: assoc key
value: assoc value]])