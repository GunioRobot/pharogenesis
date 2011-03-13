organizationFiltered: aClass
	"Return the organization of the class with all selectors defined in superclasses removed.  (except those in Object)"

	| org str |
	org := aClass organization deepCopy.
	Dangerous do: [:sel |
			org removeElement: sel].
	Approved do: [:sel |
			org removeElement: sel].
	AddAndRemove do: [:sel |
			org removeElement: sel].
	str := org printString copyWithout: $(.
	str := '(', (str copyWithout: $) ).
	str := str replaceAll: $' with: $".
	^ str
