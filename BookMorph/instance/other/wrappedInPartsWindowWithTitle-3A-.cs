wrappedInPartsWindowWithTitle: aTitle
	| aWindow |
	aWindow _ (PartsWindow labelled: aTitle) model: Model new.
	aWindow book: self.
	aWindow extent: self extent.
	^ aWindow