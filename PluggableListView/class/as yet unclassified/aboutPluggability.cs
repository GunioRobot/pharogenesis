aboutPluggability
	"A pluggable list view gets its content from the model. This allows the same kind of view can be used in different situations, thus avoiding a proliferation of gratuitous view and controller classes. Selector usage is:

		getListSel		fetch the list of items (strings) to be displayed
		getSelectionSel	get the currently selected item
		setSelectionSel	set the currently selected item (takes an argument)
		getMenuSel		get the pane-specific (or 'yellow-button') menu
		keyActionSel	process keystrokes typed to this view (takes an argument)

	Any of the above selectors can be nil, meaning that the model does not supply behavior for the given action, and the default, do-nothing behavior should be used. However, if getListSel is nil, the default behavior just provides an empty list, which makes for a rather dull list view! (Such behavior can actually be useful during debugging.)

	The model informs a pluggable view of changes by sending #changed: to itself with getListSel or getSelectionSel as a parameter. The view informs the model of selection changes by sending setSelectionSel to it with the newly selected item as a parameter, and invokes menu and keyboard actions on the model via getMenuSel and keyActionSel.

	Pluggability allows a single model object to have pluggable list views on multiple aspects of itself. For example, an object representing one personal music library might be organized as a three-level hierarchy: the types of music, the titles within a given type, and the songs on a given title. Pluggability allows one to easily build a multipane browser for this object with separate list views for the music type, title, and song."