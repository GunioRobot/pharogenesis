resumeFromDeprecatedMethods: autoResume
	"If true, make the default action for all Deprecation warnings to resume"

	| da |
	autoResume
		ifTrue: [Deprecation compiledMethodAt: #defaultAction ifAbsent: 
					[ Deprecation 
						addSelector: #defaultAction 
						withMethod: (Notification >> #defaultAction) ] ]
		ifFalse: [da _ Deprecation compiledMethodAt: #defaultAction ifAbsent: [].
				da == (Notification >> #defaultAction) 
					ifTrue: [ Deprecation basicRemoveSelector: #defaultAction] ]