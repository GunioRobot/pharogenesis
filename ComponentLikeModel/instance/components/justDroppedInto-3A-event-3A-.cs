justDroppedInto: aMorph event: anEvent
	| theModel |
	theModel _ aMorph model.
	((aMorph isKindOf: ComponentLayout) 
		and: [theModel isKindOf: Component]) ifFalse:
		["Disconnect prior to removal by move"
		(theModel isKindOf: Component) ifTrue: [self unwire.  model _ nil].
		^ self].
	theModel == model ifTrue: [^ self  "Presumably just a move"].
	self initComponentIn: aMorph