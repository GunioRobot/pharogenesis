search: multi
	"if Multi is true, collect all selectors that work."
	| old |
	selector _ OrderedCollection new.	"list of them"
	old _ Preferences autoAccessors.
	Preferences disableGently: #autoAccessors.
	self simpleSearch.
	multi not & (selector isEmpty not) ifTrue:
		[old ifTrue: [Preferences enableGently: #autoAccessors].
		^ selector].

	[self permuteArgs] whileTrue:
		[self simpleSearch.
		multi not & (selector isEmpty not) ifTrue:
			[old ifTrue: [Preferences enableGently: #autoAccessors].
			^ selector]].

	self insertConstants.
	old ifTrue: [Preferences enableGently: #autoAccessors].
	"(selector isEmpty not) ifTrue: [^ selector]].    expression is the answer, not a selector"
	^ #()