testWindowStaticLabel
	| spec |
	spec := builder pluggableWindowSpec new.
	spec model: self.
	spec children: #().
	spec label: 'TestLabel'.
	widget := builder build: spec.
	self assert: (widget label = 'TestLabel').