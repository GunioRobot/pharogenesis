fixup

	| newMorphs state fixed |

	somethingChanged _ false.
	newMorphs _ OrderedCollection new.
	state _ #new.
	fixed _ false.
	submorphs do: [ :each |
		(each isKindOf: ZASMCameraMarkMorph) ifTrue: [
			state == #mark ifTrue: [
				newMorphs add: (
					ZASMStepsMorph new setStepCount: 10
				).
				fixed _ true.
			].
			newMorphs add: each.
			state _ #mark.
		].
		(each isKindOf: ZASMStepsMorph) ifTrue: [
			state == #steps ifTrue: [
				fixed _ true.
			] ifFalse: [
				newMorphs add: each.
				state _ #steps.
			].
		].
	].
	fixed ifTrue: [
		self removeAllMorphs.
		self addAllMorphs: newMorphs.
	].