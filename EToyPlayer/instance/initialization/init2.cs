init2
	"Add property #scriptingControl _ true to all non-user toplevel morphs.  scaffold, playfield, and palettes tested separately."

	| ww nn |
	(ww _ stopButton world) ifNil: [^ self].
	stopButton setProperty: #scriptingControl toValue: true.
	stepButton setProperty: #scriptingControl toValue: true.
	goButton setProperty: #scriptingControl toValue: true.

	ww submorphs copy do: [:aMorph |
		aMorph class == TrashCanMorph ifTrue: [
			aMorph setProperty: #scriptingControl toValue: true.
			aMorph startStepping].
		aMorph class == EToyPalette ifTrue: [
				aMorph setProperty: #scriptingControl toValue: true.
				aMorph currentPalette setProperty: #scriptingControl toValue: true.].
		nn _ aMorph knownName.
		nn = 'Flush' ifTrue: [aMorph  setProperty: #scriptingControl toValue: true].
		nn = 'Badge' ifTrue: [aMorph  setProperty: #scriptingControl toValue: true].
		nn = 'Save' ifTrue: [aMorph  setProperty: #scriptingControl toValue: true].
		(aMorph class == SimpleButtonMorph) ifTrue: [
			aMorph actionSelector == #grabDrawingFromScreen ifTrue: [
				aMorph  setProperty: #scriptingControl toValue: true].
			aMorph actionSelector == #showPaintPalette ifTrue: [
				aMorph  setProperty: #scriptingControl toValue: true].
			]].
