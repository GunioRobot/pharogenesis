shrinkToChange

	| selRect baseF buf changeRect thisF thisR |
	selRect _ selectionRect innerBounds translateBy: visibleLayer topLeft negated.
	baseF _ layers first copy: selRect.
	buf _ Form extent: selRect extent depth: 16.
	changeRect _ nil.
	2 to: layers size do: [:i |
		baseF displayOn: buf.
		thisF _ (layers at: i) copy: selRect.
		thisF displayOn: buf at: 0@0 rule: 21.  "form subtract"
		thisR _ buf innerPixelRectFor: 0 orNot: true.
		thisR origin x >= 0 ifTrue: [
			changeRect ifNil: [changeRect _ thisR].
			changeRect _ changeRect merge: thisR]].
	changeRect ifNotNil: [
		selectionRect position: selectionRect innerBounds origin + changeRect origin - selectionRect borderWidth.
		selectionRect extent: changeRect extent + (2 * selectionRect borderWidth)].
	self updateSelection.
