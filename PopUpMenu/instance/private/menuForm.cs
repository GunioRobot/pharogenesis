menuForm
	"Answer a Form to be displayed for this menu."
	"Details: On slower systems, cache the menu Form for speed."

	form == nil ifFalse: [^ form].
	CacheMenuForms
		ifTrue: [^ form _ self computeForm]
		ifFalse: [^ self computeForm]