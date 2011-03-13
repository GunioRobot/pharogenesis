displayString
	^ (self theClass respondsTo: #includesLocalSelector:) 
		ifFalse: [ super displayString ]
		ifTrue: [
			(self theClass includesLocalSelector: selector)
				ifTrue: [ super displayString  ]
				ifFalse: [ 
					super displayString asText 
						addAttribute: TextEmphasis italic ] ]