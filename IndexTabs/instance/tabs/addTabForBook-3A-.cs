addTabForBook: aBook
	|  aTab |
	aTab _ ReferenceMorph forMorph: aBook.
	self addMorphBack: aTab.
	aTab highlightColor: self highlightColor; regularColor: self regularColor.
	aTab unHighlight.
	self laySubpartsOutInOneRow; layoutChanged.
	^ aTab