category: aString 
	"Categorize the receiver under the system category, aString, removing it from 
	any previous categorization."

	| oldCategory |
	oldCategory := self basicCategory.
	aString isString
		ifTrue: [
			self basicCategory: aString asSymbol.
			SystemOrganization classify: self name under: self basicCategory ]
		ifFalse: [self errorCategoryName].
	SystemChangeNotifier uniqueInstance
		class: self recategorizedFrom: oldCategory to: self basicCategory