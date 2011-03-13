collectMethodsFor: aSelector into: methodDescription
	(self includesSelector: aSelector) ifTrue: [ 
		methodDescription addLocatedMethod: (
			LocatedMethod
				location: self
				selector: aSelector)]
