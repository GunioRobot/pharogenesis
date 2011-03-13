canHaveScript
	"Return true if this morph can have an E-Toy tile script."

	^ self respondsTo: #scriptEditorFor:
