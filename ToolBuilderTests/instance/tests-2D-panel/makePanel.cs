makePanel
	| spec |
	spec := self makePanelSpec.
	widget := builder build: spec.