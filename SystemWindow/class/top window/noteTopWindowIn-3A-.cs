noteTopWindowIn: aWorld
	"TopWindow must be nil or point to the top window in this project."
	TopWindow _ nil.
	aWorld ifNil: [^ self].
	aWorld submorphsDo:
		[:m | ((m isKindOf: SystemWindow) and: [m activeOnlyOnTop])
			ifTrue: [^ m activate]]