offerPopUp
	"Put up a halo to allow user to change
		Literals (Integer, true),
		Selector (beep: sound, +,-,*,//,\\, r:g:b:, setX: incX: decX: for any X,),
		Variable (Color),
		not AssignmentNode (_ inc dec),
	Extend arrows on each literal, variable, and message, (block that is by itself).
	Retract arrows on each literal or variable, or message or block that is an argument.
	Any literal can be changed by Shift-clicking and typing."

	| panel any upDown retract extend colorPatch edge outside |
	(self hasProperty: #myPopup) ifTrue: [^ self].  "already has one"
	((outside _ self rootTile owner) isKindOf: AlignmentMorph) ifTrue: [^ self].
	  "can't put panel in right place"
	any _ false.
	(upDown _ self upDownArrows) ifNotNil: [any _ true].
	(retract _ self retractArrow) ifNotNil: [any _ true].
	(extend _ self extendArrow) ifNotNil: [any _ true].
	(colorPatch _ self colorPatch) ifNotNil: [any _ true].
	any ifFalse: [^ self].
	"Transcript cr; print: parseNode class; space; 
		print: (self hasProperty: #myPopup); endEntry."

	panel _ RectangleMorph new color: Color transparent; borderWidth: 0.
	upDown ifNotNil: [
		panel addMorphBack: upDown first.
		upDown first align: upDown first topLeft with: panel topLeft.
		panel addMorphBack: upDown second.
		upDown second align: upDown second topLeft with: upDown first bottomLeft].
	colorPatch ifNotNil: [
		panel addMorphBack: colorPatch.
		colorPatch align: colorPatch topLeft 
					with: panel topLeft].
	retract ifNotNil: [
		edge _ panel submorphs size = 0 
			ifTrue: [panel left] 
			ifFalse: [panel submorphs last right].
		panel addMorphBack: retract.
		retract align: retract topLeft with: (edge+2) @ (panel top + 3)].
	extend ifNotNil: [
		edge _ panel submorphs size = 0 
			ifTrue: [panel left] 
			ifFalse: [panel submorphs last right].
		panel addMorphBack: extend.
		extend align: extend topLeft with: (edge+2) @ (panel top + 3)].

	panel align: panel topLeft with: self topRight.
	panel extent: panel submorphs last bottomRight - panel topLeft.
	self setProperty: #myPopup toValue: panel.
	outside addMorphFront: panel.
