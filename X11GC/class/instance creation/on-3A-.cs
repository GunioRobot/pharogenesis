on: aDrawable
	| xgc |
	xgc _ self XCreateGC: aDrawable display with: aDrawable with: 0 with: nil.
	xgc drawable: aDrawable.
	^xgc