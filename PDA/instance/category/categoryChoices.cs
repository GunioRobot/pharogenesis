categoryChoices
	"Return a list for the popup chooser"
	| special |
	special _ {'all'. 'recurring'. nil}.
	(special includes: category) ifTrue:
		[^ special , userCategories , {nil. 'add new key'}].
	^ special , userCategories , {nil. 'remove ' , self categorySelected. 'rename ' , self categorySelected. nil. 'add new key'}