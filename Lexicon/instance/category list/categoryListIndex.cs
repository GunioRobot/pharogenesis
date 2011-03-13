categoryListIndex
	"Answer the index of the currently-selected item in in the category list"

	^ categoryListIndex ifNil: [categoryListIndex := 1]