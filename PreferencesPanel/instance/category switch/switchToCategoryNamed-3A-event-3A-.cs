switchToCategoryNamed: aName event: anEvent
	"Switch the panel so that it looks at the category of the given name"

	| aPalette |
	aPalette _ self containingWindow findDeeplyA: TabbedPalette.
	aPalette ifNil: [^ self].
	aPalette selectTabNamed: aName