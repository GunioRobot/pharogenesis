arguments: anArray
	arguments _ WeakArray withAll: anArray.
	"no reason this should be a WeakArray"
	shouldBeNil _ Array withAll: (anArray collect: [ :ea | ea isNil ]).
