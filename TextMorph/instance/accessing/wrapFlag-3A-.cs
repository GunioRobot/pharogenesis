wrapFlag: aBoolean
	"Change whether contents are wrapped to the container."

	aBoolean == wrapFlag ifTrue: [^ self].
	wrapFlag := aBoolean.
	self composeToBounds