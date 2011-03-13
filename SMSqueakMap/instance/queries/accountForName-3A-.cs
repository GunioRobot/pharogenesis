accountForName: name
	"Find account given full name. Disregarding case
	and allows up to 2 different characters.
	Size must match though, someone else can be smarter -
	this is just for migrating accounts properly."

	| lowerName size aName |
	lowerName := name asLowercase.
	size := lowerName size.
	^self accounts
		detect: [:a |
			aName := a name asLowercase.
			(aName size = size) and: [| errors |
				errors := 0.
				aName with: lowerName do: [:c1 :c2 |
					c1 ~= c2 ifTrue: [errors := errors + 1]].
				errors < 3
			]]
		ifNone: [nil]
		