packageHighlight: aStringCollection with: aMorphCollection

	aStringCollection with: aMorphCollection do: [ :string :entry |
		| emph |
		emph _ 0.
		(loaded anySatisfy: [:each | (each copyUpToLast: $-) = string])
			ifTrue: [
				entry emphasis: ((newer includes: string)
					ifTrue: [5] ifFalse: [4])]].