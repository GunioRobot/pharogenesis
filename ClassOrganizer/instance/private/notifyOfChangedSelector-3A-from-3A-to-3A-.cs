notifyOfChangedSelector: element from: oldCategory to: newCategory
	(self hasSubject and: [(oldCategory ~= newCategory)]) ifTrue: [
		SystemChangeNotifier uniqueInstance selector: element recategorizedFrom: oldCategory to: newCategory inClass: self subject
	].