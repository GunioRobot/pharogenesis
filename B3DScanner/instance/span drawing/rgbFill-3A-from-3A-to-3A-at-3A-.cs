rgbFill: face from: leftEdge to: rightEdge at: yValue
	"Using only RGB (no alpha no textures)"
	| leftX rightX floatY floatX rValue gValue bValue pv rAttr gAttr bAttr |
	"Note: We always sample at pixel centers.
	If the edges do not include this pixel center, do nothing.
	Otherwise fill from leftX to rightX, including both pixels."
	leftX _ (leftEdge xValue bitShift: -12) + 1.
	rightX _ rightEdge xValue bitShift: -12.
	leftX < 0 ifTrue:[leftX _ 0].
	rightX >= spanBuffer size ifTrue:[rightX _ spanBuffer size-1].
	leftX > rightX ifTrue:[^self].

	B3DScanner doDebug ifTrue:[
		"Sanity check."
		(face leftEdge xValue > leftEdge xValue)
			ifTrue:[
				(face rightEdge xValue < rightEdge xValue)
					ifTrue:[self error:'Filling outside face']
					ifFalse:[self error:'Filling left of face'].
		] ifFalse:[(face rightEdge xValue < rightEdge xValue)
						ifTrue:[self error:'Filling right of face']].
	].

	(face flags anyMask: FlagFaceInitialized) ifFalse:[
		face initializePass2.
		face flags: (face flags bitOr: FlagFaceInitialized)].

	"@@: Sampling problem!"
	floatY _ yValue + 0.5.
	floatX _ leftX.

	rAttr _ face attributes.
	gAttr _ rAttr nextAttr.
	bAttr _ gAttr nextAttr.

	rValue _ (face attrValue: rAttr atX: floatX y: floatY).
	gValue _ (face attrValue: gAttr atX: floatX y: floatY).
	bValue _ (face attrValue: bAttr atX: floatX y: floatY).

	[leftX <= rightX] whileTrue:[
		rValue _ rValue min: 255.0 max: 0.0.
		gValue _ gValue min: 255.0 max: 0.0.
		bValue _ bValue min: 255.0 max: 0.0.

		pv _ (bValue truncated) +
				(gValue truncated bitShift: 8) +
					(rValue truncated bitShift: 16).
		spanBuffer at: (leftX _ leftX+1) put: (pv bitOr: 4278190080).
		rValue _ rValue + rAttr dvdx.
		gValue _ gValue + gAttr dvdx.
		bValue _ bValue + bAttr dvdx].
