addTabFor: aReferent font: aFont
	| aTab |
	aTab _ tabsMorph addTabFor: aReferent font: aFont.
	pages add: aReferent.
	currentPage ifNil: [currentPage _ aReferent].
	^ aTab