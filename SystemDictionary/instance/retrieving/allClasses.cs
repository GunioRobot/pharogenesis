allClasses  
	"Return all the class defines in the Smalltalk SystemDictionary"
	"Smalltalk allClasses"

	^ self classNames collect: [:name | self at: name]