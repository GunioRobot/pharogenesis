makeWindow
	| spec |
	spec := self makeWindowSpec.
	widget := builder build: spec.