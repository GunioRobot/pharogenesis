addCurves
	"Add the polyLine corresponding to the currently selected envelope,
	and possibly all the others, too."
	| verts aLine |
	sound envelopes do:
		[:env | 
		(showAllEnvelopes or: [env == envelope]) ifTrue:
			[verts _ env points collect:
				[:p | (self xFromMs: p x) @ (self yFromValue: p y)].
			aLine _ EnvelopeLineMorph basicNew
						vertices: verts borderWidth: 1
						borderColor: (self colorForEnvelope: env).
			env == envelope
				ifTrue: [aLine borderWidth: 2.  line _ aLine]
				ifFalse: [aLine on: #mouseUp send: #clickOnLine:evt:envelope:
							to: self withValue: env.
						self addMorph: aLine]]].
	self addMorph: line  "add the active one last (in front)"