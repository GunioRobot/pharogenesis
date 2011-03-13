testLocalMethodWithSameCodeInTrait
	"Note, takes all behaviors (classes and traits) into account"

	SystemNavigation default allBehaviorsDo: [ :each |
		each hasTraitComposition ifTrue: [
			each methodDict keys do: [ :selector |
				(each includesLocalSelector: selector) ifTrue: [
					(each traitComposition traitProvidingSelector: selector) ifNotNil: [ :trait |
						self deny: (trait >> selector = (each >> selector)) ] ] ] ] ].