acquirePlayerSimilarTo: aSketchMorphsPlayer
	"Retrofit into the receiver a player derived from the existing scripted player of a different morph.  Works only between SketchMorphs. Maddeningly complicated by potential for transformations or native sketch-morph scaling in donor or receiver or both"

	| myName myTop itsTop newTop newSketch |
	myTop := self topRendererOrSelf.
	aSketchMorphsPlayer belongsToUniClass ifFalse: [^ Beeper beep].
	itsTop := aSketchMorphsPlayer costume.
	(itsTop renderedMorph isSketchMorph)
		ifFalse:	[^ Beeper beep].

	newTop := itsTop veryDeepCopy.  "May be a sketch or a tranformation"
	myName := myTop externalName.  "Snag before the replacement is added to the world, because otherwise that could affect this"

	newSketch := newTop renderedMorph.
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
	newTop := newSketch topRendererOrSelf.
	newTop bounds: self bounds.
	(newTop isFlexMorph and:[myTop isFlexMorph]) ifTrue:[
		"Note: This completely dumps the above #bounds: information.
		We need to recompute the bounds based on the transform."
		newTop transform: myTop transform copy.
		newTop computeBounds].
	newTop setNameTo: myName.
	newTop player class bringScriptsUpToDate.
	myTop delete