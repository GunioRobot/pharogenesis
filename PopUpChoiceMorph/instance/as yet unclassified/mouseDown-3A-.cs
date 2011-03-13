mouseDown: evt

	| items menu selectedItem |
	(target == nil or: [getItemsSelector == nil]) ifTrue: [^ self].
	items _ target perform: getItemsSelector withArguments: getItemsArgs.
	menu _ CustomMenu new.
	items do: [:item | menu add: item action: item].
	selectedItem _ menu startUp.
	selectedItem ifNil: [^ self].
	self contentsClipped: selectedItem.  "Client can override this if necess"
	actionSelector ifNotNil: [
		target
			perform: actionSelector
			withArguments: (arguments copyWith: selectedItem)].
