organizationFiltered: aClass
	"Return the organization of the class with all selectors defined in superclasses removed.  (except those in Object)"

	| org str |
	org _ aClass organization deepCopy.
	Dangerous do: [:sel |
			org removeElement: sel].
	Approved do: [:sel |
			org removeElement: sel].
	AddAndRemove do: [:sel |
			org removeElement: sel].
	str _ org printString copyWithout: $(.
	str _ '(', (str copyWithout: $) ).
	str _ str replaceAll: $' with: $".
	^ str
