atID: id
	"Return page of a given key."

	^pages detect: [:page | page coreID = id] ifNone: [pages at: 'Front Page']