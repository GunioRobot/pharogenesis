morphToDropFrom: aMorph
	"Answer the morph to drop if the user attempts to drop aMorph"

	| aButton |
	aButton _ IconicButton new.
	aButton color: self color;
		initializeToShow: aMorph withLabel: aMorph externalName andSend: #veryDeepCopy to: aMorph veryDeepCopy.
	^ aButton