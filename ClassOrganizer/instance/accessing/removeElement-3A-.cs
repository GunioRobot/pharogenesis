removeElement: element
	| oldCat |
	oldCat _ self categoryOfElement: element.
	SystemChangeNotifier uniqueInstance doSilently: [
		super removeElement: element].
	self notifyOfChangedSelector: element from: oldCat to: (self categoryOfElement: element).