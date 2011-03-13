wrappedInPartsWindowWithTitle: aTitle
	| aWindow |

	self fullBounds.
	aWindow _ (PartsWindow labelled: aTitle) model: Model new.
	aWindow book: self.
	^ aWindow