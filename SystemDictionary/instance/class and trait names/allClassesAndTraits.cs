allClassesAndTraits
	"Return all the classes and traits defined in the Smalltalk SystemDictionary"

	^ self classNames , self traitNames collect: [:each | self at: each]