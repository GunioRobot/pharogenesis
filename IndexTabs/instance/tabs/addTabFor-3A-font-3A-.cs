addTabFor: aReferent font: aFont
	|  aTab |
	aTab _ ReferenceMorph forMorph: aReferent font: aFont.
	self addMorphBack: aTab.
	aTab highlightColor: self highlightColor; regularColor: self regularColor.
	aTab unHighlight.
	self laySubpartsOutInOneRow; layoutChanged.
	^ aTab