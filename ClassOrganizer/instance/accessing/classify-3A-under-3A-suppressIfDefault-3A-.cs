classify: element under: heading suppressIfDefault: aBoolean
	| oldCat newCat |
	oldCat _ self categoryOfElement: element.
	SystemChangeNotifier uniqueInstance doSilently: [
		super classify: element under: heading suppressIfDefault: aBoolean].
	newCat _ self categoryOfElement: element.
	self notifyOfChangedSelector: element from: oldCat to: newCat.