removeSelector: selector class: class 
	"Include indication that a method has been forgotten."

	(self atSelector: selector class: class) = #add
		ifTrue: [self atSelector: selector
					class: class
					put: #addedThenRemoved]
		ifFalse: [self atSelector: selector
					class: class
					put: #remove].

	(class includesSelector: selector) ifTrue:
		["Save the source code pointer and category so can still browse old versions"
		methodRemoves at: (Array with: class name with: selector)
			put: (Array with: (class compiledMethodAt: selector) sourcePointer
						with: (class whichCategoryIncludesSelector: selector))]