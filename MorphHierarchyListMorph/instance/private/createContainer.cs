createContainer
	"Private - Create a container"
	| container |
	container := BorderedMorph new.
	container extent: (World extent * (1 / 4 @ (2 / 3))) rounded.
	container layoutPolicy: TableLayout new.
	container hResizing: #rigid.
	container vResizing: #rigid.
	container
		setColor: Preferences menuColor
		borderWidth: Preferences menuBorderWidth
		borderColor: Preferences menuBorderColor.
	container layoutInset: 0.
	"container useRoundedCorners."
	""
	container setProperty: #morphHierarchy toValue: true.
	container setNameTo: 'Objects Hierarchy' translated.
	""
	^ container