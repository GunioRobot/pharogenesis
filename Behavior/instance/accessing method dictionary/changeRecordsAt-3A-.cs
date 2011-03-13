changeRecordsAt: selector
	"Return a list of ChangeRecords for all versions of the method at selector.
	Source code can be retrieved by sending string to any one"
	"(Pen changeRecordsAt: #go:) collect: [:cRec | cRec string]"
	^ (ChangeList new
			scanVersionsOf: (self compiledMethodAt: selector)
			class: self meta: self isMeta
			category: (self whichCategoryIncludesSelector: selector)
			selector: selector)
		changeList