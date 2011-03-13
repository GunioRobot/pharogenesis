name: aString example: anotherString features: anArray
	| answer |
	answer := self new name: aString; example: anotherString.
	anArray do: [ :each | answer addProperty: each].
	^ answer