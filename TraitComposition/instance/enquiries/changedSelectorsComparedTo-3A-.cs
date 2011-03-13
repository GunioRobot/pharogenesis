changedSelectorsComparedTo: oldComposition
	| changedSelectors oldTransformation traits newTransformation |
	changedSelectors := IdentitySet new.
	traits := self traits asIdentitySet addAll: oldComposition traits asIdentitySet; yourself.
	traits do: [:each |
		newTransformation := self transformationOfTrait: each.
		oldTransformation := oldComposition transformationOfTrait: each.
		(newTransformation isNil or: [oldTransformation isNil])
			ifTrue: [
				changedSelectors addAll: each selectors]
			ifFalse: [
				changedSelectors addAll: 
					(newTransformation changedSelectorsComparedTo: oldTransformation)]].
	^changedSelectors