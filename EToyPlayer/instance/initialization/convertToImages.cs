convertToImages
	"One time conversion from ellipses to images for Stop, Step, Go button.  Works on open EToys."

	| ww tcm |
		"stopButton class == EllipseMorph ifFalse: [^ self]."  
		"Do this to all worlds, even if just to move buttons around."
	(ww _ stopButton world) ifNil: [^ self].
	stopButton delete.
	stepButton delete.
	goButton delete.
	ww submorphs copy do: [:aMorph |
		aMorph class == TrashCanMorph ifTrue: [aMorph delete].
			].

		"self addControlsFor: eToyHolder inWorld: ww."
	self addStopStepGoButtonsTo: ww.
		"self addLowerLeftButtonsTo: ww."
	tcm _ TrashCanMorph newSticky position: ww extent - (58@76).
	ww addMorph: tcm.
	tcm startStepping.
	tcm setProperty: #scriptingControl toValue: true.
