subProjects
	"Answer a list of all the subprojects  of the receiver.  This is nastily idiosyncratic."

	^self isMorphic 
		ifTrue: 
			[world submorphs 
				select: [:m | (m isSystemWindow) and: [m model isKindOf: Project]]
				thenCollect: [:m | m model]]
		ifFalse: 
			[(world controllersSatisfying: [:m | m model isKindOf: Project]) 
				collect: [:c | c model]]