widthOf: char

	"This method cannot use #formOf: because formOf: discriminates the color and causes unnecessary bitmap creation."

	| newForm |
	self hasCached: char ifTrue: [:form :index |
		self access: char at: index.
		^ form width.
	].

	newForm _ self computeForm: char.
	self at: char put: newForm.
	^ newForm width.

