addUpdating: wordingSelector target: target selector: aSymbol argumentList: argList
	"Append a menu item with the given label. If the item is selected, it will send the given selector to the target object with the given arguments. If the selector takes one more argument than the number of arguments in the given list, then the triggering event is supplied as as the last argument.  In this variant, the wording of the menu item is obtained by sending the wordingSelector to the target"

	| item |
	item _ UpdatingMenuItemMorph new
		target: target;
		selector: aSymbol;
		wordingProvider: target wordingSelector: wordingSelector;
		arguments: argList asArray.
	self addMorphBack: item.
