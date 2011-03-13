currentItem
	"Return the value of currentItem"
	currentItem ifNil: [^ 'No item is selected.'].
	^ currentItem