mouseDown: evt 
	| items menu selectedItem |
	(target isNil or: [getItemsSelector isNil]) ifTrue: [^self].
	items := target perform: getItemsSelector withArguments: getItemsArgs.
	menu := CustomMenu new.
	items do: [:item | menu add: item action: item].
	selectedItem := menu startUp.
	selectedItem ifNil: [^self].
	self contentsClipped: selectedItem.	"Client can override this if necess"
	actionSelector ifNotNil: 
			[target perform: actionSelector
				withArguments: (arguments copyWith: selectedItem)]