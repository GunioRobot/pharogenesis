menuItemAfter: menuString
	| allWordings |
	allWordings _ self allMenuWordings.
	^ allWordings atWrap: ((allWordings indexOf: menuString) + 1)