accountForName: name
	"Find account given full name. Disregarding case
	and allows up to 2 different characters.
	Size must match though, someone else can be smarter -
	this is just for migrating accounts properly."

	| lowerName size aName |
	lowerName _ name asLowercase.
	size _ lowerName size.
	^self accounts
		detect: [:a |
			aName _ a name asLowercase.
			(aName size = size) and: [| errors |
				errors _ 0.
				aName with: lowerName do: [:c1 :c2 |
					c1 ~= c2 ifTrue: [errors _ errors + 1]].
				errors < 3
			]]
		ifNone: [nil]
		