createCustomModel
	"Create a model object for this world if it does not yet have one.
	The default model for an EditView is a Component."

	model isNil ifFalse: [^self].	"already has a model"
	model := Component newSubclass new