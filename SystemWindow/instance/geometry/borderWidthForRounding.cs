borderWidthForRounding
	"Pane borders effectively increase the border size.
	This is a hack, but it usually looks good."

	self isCollapsed ifTrue: [^2].
	(paneMorphs notNil 
		and: [paneMorphs notEmpty and: [paneMorphs first borderWidth > 0]]) 
			ifTrue: [^self borderWidth + paneMorphs first borderWidth]
			ifFalse: [^self borderWidth]