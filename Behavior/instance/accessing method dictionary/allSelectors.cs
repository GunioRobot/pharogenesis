allSelectors
	"Answer a Set of all the message selectors that instances of the receiver 
	can understand."

	| temp |
	superclass == nil
		ifTrue: [^self selectors]
		ifFalse: [temp _ superclass allSelectors.
				temp addAll: self selectors.
				^temp]

	"Point allSelectors"