findClassIn: anEnvironment
	| pattern class |
	pattern := OBTextRequest 
					prompt: 'Please type the name or fragment to look for' 
					template: ''.
	pattern ifNil: [^self].
	class := self findClassIn: anEnvironment pattern: pattern.
	class ifNotNil: [(class asNode) signalSelection].