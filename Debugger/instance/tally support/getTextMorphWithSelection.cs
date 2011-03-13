getTextMorphWithSelection
	"This is extremely ugly... We I need to get a reference of the code pane, which is not easily accessible"
	^ (self dependents select: [:m| m isKindOf: PluggableTextMorph]) 
		detect: [:m| m selectionInterval first > 1] ifNone: [nil]