initialize
	"Hook us up in the world menu."

	 (TheWorldMenu respondsTo: #registerOpenCommand:)
         ifTrue: [
		TheWorldMenu registerOpenCommand: {'SqueakMap Package Loader'. {self. #open}}.
		TheWorldMenu unregisterOpenCommand: 'Package Loader'].
	DefaultFilters _ OrderedCollection new.
	DefaultCategoriesToFilterIds _ OrderedCollection new
