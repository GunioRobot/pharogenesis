changeFromCategorySpecs: categorySpecs 
	"Tokens is an array of categorySpecs as scanned from a browser 'reorganize' pane, or built up by some other process, such as a scan of an environment."

	| oldElements newElements newCategories newStops currentStop temp ii cc catSpec |
	oldElements _ elementArray asSet.
	newCategories _ Array new: categorySpecs size.
	newStops _ Array new: categorySpecs size.
	currentStop _ 0.
	newElements _ WriteStream on: (Array new: 16).
	1 to: categorySpecs size do: 
		[:i | | selectors |
		catSpec _ categorySpecs at: i.
		newCategories at: i put: catSpec first asSymbol.
		selectors := catSpec allButFirst collect: [:each | each isSymbol
							ifTrue: [each]
							ifFalse: [each printString asSymbol]].
		selectors asSortedCollection do:
			[:elem |
			(oldElements remove: elem ifAbsent: [nil]) notNil ifTrue:
				[newElements nextPut: elem.
				currentStop _ currentStop+1]].
		newStops at: i put: currentStop].

	"Ignore extra elements but don't lose any existing elements!"
	oldElements _ oldElements collect:
		[:elem | Array with: (self categoryOfElement: elem) with: elem].
	newElements _ newElements contents.
	categoryArray _ newCategories.
	(cc _ categoryArray asSet) size = categoryArray size ifFalse: ["has duplicate element"
		temp _ categoryArray asOrderedCollection.
		temp removeAll: categoryArray asSet asOrderedCollection.
		temp do: [:dup | 
			ii _ categoryArray indexOf: dup.
			[dup _ (dup,' #2') asSymbol.  cc includes: dup] whileTrue.
			cc add: dup.
			categoryArray at: ii put: dup]].
	categoryStops _ newStops.
	elementArray _ newElements.
	oldElements do: [:pair | self classify: pair last under: pair first].