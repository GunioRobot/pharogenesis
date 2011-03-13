listChanged
	"set newList to be the list of strings to display"
	listItems := (1 to: self getListSize) collect: [:i |
		self getListItem: i].
	self removeAllMorphs.
	listItems do: [:i | self addMorphBack: i].
	selectedRow := nil.
	selectedRows := PluggableSet integerSet.
	maxWidth := nil. "recompute"
	self
		adjustHeight;
		adjustWidth.
	listItems do: [:i | i layoutChanged].
	self changed.
