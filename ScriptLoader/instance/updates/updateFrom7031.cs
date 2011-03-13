updateFrom7031

	"self new updateFrom7031"
	"
	- Shift ivars traitComposition and localSelectors because of problem with hardcoded indexes in VM (this is accomplished in combination with a cs which has to be loaded first)
	- refactor accessing trait compositions to avoid unnecessary lazy initialization
	- recategorizing methods from *Traits extensions to local packages
	- new requires algorithm tests by Andrew Black
	"
	
	self script64.
	
	"To get rid of already created empty compositions in the image"
	Smalltalk allClassesAndTraitsDo: [ :each |
	(each instVarNamed: 'traitComposition') notNil and: [
		each traitComposition allTraits isEmpty ifTrue: [
			each instVarNamed: 'traitComposition' put: nil ] ] ].

	"Initialization required for tests"
	SendCaches initializeAllInstances.

	self flushCaches.
	MCDefinition clearInstances.
	