hasAnyChangeForSelector: aSelector
	"Answer whether the receiver has any change under the given selector, whether it be add, change, or remove, for any class"

	changeRecords do:
		[:aRecord | (aRecord changedSelectors  includes: aSelector)
			ifTrue:	[^ true]].
	^ false