fixAlansOldEventHandlers
"
EventHandler fixAlansOldEventHandlers
"
	| allHandlers |

	allHandlers _ EventHandler allInstances select: [ :each |
		(#(programmedMouseUp:for: programmedMouseUp:for:with:) includes: 
				each mouseUpSelector) and: [each mouseDownSelector isNil]
	].
	allHandlers do: [ :each |
		each fixAlansOldEventHandlers
	].