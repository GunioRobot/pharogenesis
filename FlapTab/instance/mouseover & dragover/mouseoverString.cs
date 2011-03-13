mouseoverString
	"Answer the string to be shown in a menu to represent the mouseover status"

	^ popOutOnMouseOver
		ifTrue:
			['<yes>pop out on mouseover']
		ifFalse:
			['<no>pop out on mouseover']