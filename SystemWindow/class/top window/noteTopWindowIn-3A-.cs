noteTopWindowIn: aWorld
	| newTop |
	"TopWindow must be nil or point to the top window in this project."
	TopWindow _ nil.
	aWorld ifNil: [^ self].
	newTop _ nil.
	aWorld submorphsDo:
		[:m | (m isKindOf: SystemWindow) ifTrue:
			[(newTop == nil and: [m activeOnlyOnTop])
				ifTrue: [newTop _ m].
			(m model isKindOf: Project)
				ifTrue: ["This really belongs in a special ProjWindow class"
						m label ~= m model name ifTrue: [m setLabel: m model name]]]].
	newTop == nil ifFalse: [newTop activate]