initialize
	"Initialize the class"

	self registerInFlapsRegistry.	
	ScriptingSystem addCustomEventFor: self named: #keyStroke help: 'when a keystroke happens and nobody heard it' targetMorphClass: PasteUpMorph.