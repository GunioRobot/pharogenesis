category: cat 
	"Categorize the receiver under the system category, cat, removing it from 
	any previous categorization."

	| oldCat |
	oldCat := self category.
	(cat isString)
		ifTrue: [SystemOrganization classify: self name under: cat asSymbol]
		ifFalse: [self errorCategoryName].
	SystemChangeNotifier uniqueInstance class: self recategorizedFrom: oldCat to: cat asSymbol