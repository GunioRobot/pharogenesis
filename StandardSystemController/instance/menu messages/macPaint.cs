macPaint
	"Create a MacPaint diskfile of the view's contents.  The resulting diskfile can be printed using MacPaint."
	| f menuIndex |
	menuIndex _ (PopUpMenu labels: 'cancel printing
show label
hide label') startUpWithCaption: 'Should the label tag be included?'.
	menuIndex <= 1 ifTrue: [^self].
	f _ FileStream fileNamed: (view label,'.paint').
	menuIndex == 2
		ifTrue: [view deEmphasizeLabel.
				(Form fromDisplay: view displayBox)
					bigMacPaintOn: f label: view labelDisplayBox.
				view emphasizeLabel.]
		ifFalse: [(Form fromDisplay: view displayBox) bigMacPaintOn: f].
	f close