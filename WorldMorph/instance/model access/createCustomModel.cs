createCustomModel
	"Create a model object for this world if it does not yet have one. A model object is an initially empty subclass of MorphicModel. As the user names parts and adds behavior, instance variables and methods are added to this class."

	model == nil ifFalse: [^ self].  "already has a model"
	model _ MorphicModel newSubclass new.
