buildPluggableList: aSpec
	"Build an appropriate pluggable list."
	
	| widget |
	aSpec icon
		ifNil: [widget := super buildPluggableList: aSpec]
		ifNotNil: [widget := PluggableIconListMorph new
					getIconSelector: aSpec icon;
					on: aSpec model
					list: aSpec list
					selected: aSpec getIndex
					changeSelected: aSpec setIndex
					menu: aSpec menu
					keystroke: aSpec keyPress.
				self register: widget id: aSpec name.
				widget autoDeselect: aSpec autoDeselect.
				self setFrame: aSpec frame in: widget.
				parent ifNotNil:[self add: widget to: parent].
				panes ifNotNil:[aSpec list ifNotNil:[panes add: aSpec list]]].
	widget doubleClickSelector: aSpec action.
	^widget