initialize
	"Hook us up in the world menu."
	
	"self initialize"

	self registerInFlapsRegistry.
	(Preferences windowColorFor: #SMLoader) = Color white "not set"
		ifTrue: [ Preferences setWindowColorFor: #SMLoader to: (Color colorFrom: self windowColorSpecification brightColor) ].
	 (TheWorldMenu respondsTo: #registerOpenCommand:)
         ifTrue: [
		TheWorldMenu registerOpenCommand: {'SqueakMap Package Loader'. {self. #open}}.
		TheWorldMenu unregisterOpenCommand: 'Package Loader'].
	DefaultFilters := OrderedCollection new.
	DefaultCategoriesToFilterIds := OrderedCollection new
