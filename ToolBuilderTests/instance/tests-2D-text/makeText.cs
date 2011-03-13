makeText
	| spec |
	spec := self makeTextSpec.
	widget := builder build: spec.