changes
	"Answer the changes tree roots."

	|changes classes|
	self model ifNil: [^#()].
	changes := OrderedCollection new.
	classes := Set new.
	self model do: [:o |
		(o definition isOrganizationDefinition or: [o targetClassName isNil])
			ifTrue: [changes add: (o patchWrapper model: self model)]
			ifFalse: [(classes includes: o targetClassName)
					ifFalse: [classes add: o targetClassName.
							changes add: (PSMCClassChangeWrapper with: o targetClassName model: self model)]]].
	^changes