acquirePlayerSimilarTo: aSketchMorphsPlayer
	"Retrofit into the receiver a player derived from the existing scripted player of a different morph.  Works only between SketchMorphs. Maddeningly complicated by potential for transformations or native sketch-morph scaling in donor or receiver or both"

	| myName myTop itsTop newTop newSketch |
	myTop _ self topRendererOrSelf.
	aSketchMorphsPlayer belongsToUniClass ifFalse: [^ Beeper beep].
	itsTop _ aSketchMorphsPlayer costume.
	(itsTop renderedMorph isSketchMorph)
		ifFalse:	[^ Beeper beep].

	newTop _ itsTop veryDeepCopy.  "May be a sketch or a tranformation"
	myName _ myTop externalName.  "Snag before the replacement is added to the world, because otherwise that could affect this"

	newSketch _ newTop renderedMorph.
	newSketch form: self form.
	newSketch scalePoint: self scalePoint.
	newSketch bounds: self bounds.
	myTop owner addMorph: newTop after: myTop.

	newTop heading ~= myTop heading ifTrue:
		"avoids annoying round-off error in what follows"
			[newTop player setHeading: myTop heading]. 
	(newTop isFlexMorph and: [myTop == self])
		ifTrue:
			[newTop removeFlexShell].
	newTop _ newSketch topRendererOrSelf.
	newTop bounds: self bounds.
	(newTop isFlexMorph and:[myTop isFlexMorph]) ifTrue:[
		"Note: This completely dumps the above #bounds: information.
		We need to recompute the bounds based on the transform."
		newTop transform: myTop transform copy.
		newTop computeBounds].
	newTop setNameTo: myName.
	newTop player class bringScriptsUpToDate.
	myTop delete