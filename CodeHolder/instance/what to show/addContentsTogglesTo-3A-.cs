addContentsTogglesTo: aMenu 
	"Add updating menu toggles governing contents to aMenu."
	self contentsSymbolQuints
		do: [:aQuint | aQuint == #-
				ifTrue: [aMenu addLine]
				ifFalse: [Smalltalk isMorphic
						ifTrue: [aMenu
								addUpdating: aQuint third
								target: self
								action: aQuint second.
							aMenu balloonTextForLastItem: aQuint fifth]
						ifFalse: [aMenu
								add: (('<yes>*' match: (self perform: aQuint third)) ifTrue: ['*'] ifFalse: ['']), aQuint fourth
								target: self
								selector: #contentsSymbol: 
								argumentList: { aQuint first } ]]]