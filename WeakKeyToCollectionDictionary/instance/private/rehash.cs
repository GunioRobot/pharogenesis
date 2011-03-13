rehash
	"Rehash the receiver. Reimplemented to remove nils from the collections
	that appear as values, and to entirely remove associations with empty collections 
	as values."
	| oldArray assoc cleanedValue newIndex |
	oldArray := array.
	array := Array new: oldArray size.
	tally := 0.
	1 to: array size do: [:i | 
			assoc := oldArray at: i.
			(assoc notNil
					and: [(cleanedValue := assoc value copyWithout: nil) notEmpty])
				ifTrue: [newIndex := self scanForNil: assoc key.
					assoc value: cleanedValue.
					self atNewIndex: newIndex put: assoc]]