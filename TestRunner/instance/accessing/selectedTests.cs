selectedTests
	| retval |
	retval _ OrderedCollection new.
	tests with: selectedSuites do: [ :str :sel | sel ifTrue: [ retval add: str ]].
	^retval
