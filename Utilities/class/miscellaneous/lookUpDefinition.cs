lookUpDefinition
	| aWord aDefinition |
	(aWord _ FillInTheBlank request: 'Enter a word:') isEmpty ifTrue: [^ self].
	(aDefinition _ WordNet definitionsFor: aWord) ifNil: [^ self].
	(StringHolder new contents: aDefinition)
		openLabel: aWord

"Utilities lookUpDefinition"