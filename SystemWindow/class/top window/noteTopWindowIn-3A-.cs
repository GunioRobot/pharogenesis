noteTopWindowIn: aWorld
	| newTop |
	"TopWindow must be nil or point to the top window in this project."
	TopWindow := nil.
	aWorld ifNil: [^ self].
	newTop := nil.
	aWorld submorphsDo:
		[:m | (m isSystemWindow) ifTrue:
			[(newTop == nil and: [m activeOnlyOnTop])
				ifTrue: [newTop := m].
			(m model isKindOf: Project)
				ifTrue: ["This really belongs in a special ProjWindow class"
						m label ~= m model name ifTrue: [m setLabel: m model name]]]].
	newTop == nil ifFalse: [newTop activate]