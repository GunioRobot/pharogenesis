formOf: char

	| newForm |
	self hasCached: char ifTrue: [:form :index |
		self access: char at: index.
		^ form.
	].

	newForm _ self computeForm: char.
	self at: char put: newForm.
	^ newForm.
