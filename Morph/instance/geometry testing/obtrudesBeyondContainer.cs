obtrudesBeyondContainer
	"Answer whether the receiver obtrudes beyond the bounds of its container"

	| top |
	top _ self topRendererOrSelf.
	(top owner == nil or: [top owner isHandMorph]) ifTrue: [^ false].
	^ (top owner bounds containsRect: top bounds) not
	