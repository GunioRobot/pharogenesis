mouseDown: evt

	| menu selectedItem |
	self items isEmpty ifTrue: [^ self].
	menu _ CustomMenu new.
	self items do: [:item | menu add: item action: item].
	selectedItem _ menu startUp.
	selectedItem ifNil: [^ self].
	self contentsClipped: selectedItem.  "Client can override this if necess"
	actionSelector ifNotNil: [
		target
			perform: actionSelector
			withArguments: (arguments copyWith: selectedItem)].
