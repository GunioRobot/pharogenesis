inspect
	"Create and schedule an Inspector in which the user can examine the 
	receiver's variables."
	| insp |
	World ifNotNil:
		["Written so that Morphic can still be removed."
		insp _ (Smalltalk at: #ObjectInspector) on: self.
		^ self world addMorph: insp; startStepping: insp].
	Inspector openOn: self withEvalPane: true