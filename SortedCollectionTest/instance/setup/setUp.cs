setUp

	nonEmpty := SortedCollection new.
	elementExistsTwice := 12332312321.
	nonEmpty add: 2.
	nonEmpty add: elementExistsTwice.
	nonEmpty add: elementExistsTwice.
	collectionIncluded := SortedCollection new add: 2; add: elementExistsTwice ;yourself.
	collectionNotIncluded := SortedCollection new add: 312; add: 313 ;yourself.
	empty := SortedCollection  new. 
	collection := SortedCollection new.
	collection add: 1.
	collection add: -2.
	collection add: 3.
	collection add: 1.
	collectionWithoutNil := SortedCollection new add: 1;add: 2 ;add:4 ;add:5;yourself.
	result := OrderedCollection new. "SortedCollection sortBlock: [:a :b | a name < b name]."
	result add: SmallInteger.
	result add: SmallInteger.
	result add: SmallInteger.
	result add: SmallInteger.
	nonEmpty1Element := SortedCollection new add:5; yourself.
	collectionOfFloat := SortedCollection new add:1.2 ; add: 5.6 ; add:4.4 ; add: 1.9 ; yourself.
	duplicateFloat := 1.2.
	collectionOfFloatWithDuplicate := SortedCollection new add: duplicateFloat  ; add: 5.6 ; add:4.4 ; add: duplicateFloat  ; yourself.
	accessCollection := SortedCollection new add:1 ; add: 5 ; add:4 ; add: 2 ; add:7 ; yourself.
	elementNoteIn := 999.
	oldSubcollection := SortedCollection new add: 2 ; add: 2 ; add: 2 ; yourself.
	floatCollectionSameEndAndBegining := SortedCollection new add: 1.5 ; add: 1.5 copy ; yourself.
	withoutEqualElements := SortedCollection new add: 1 ; add: 8 copy ; add: 4;yourself.
	nonEmpty5Elements := SortedCollection new add: 1 ; add: 8 copy ; add: 4; add: 4; add: 4;yourself.